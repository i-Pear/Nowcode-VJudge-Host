import time
import request
import pymysql
import datetime
import pyperclip
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver import support, ActionChains
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.common.desired_capabilities import DesiredCapabilities
from selenium.webdriver.support import expected_conditions


def getProblemURL(ContestURLBase, countdown):
    result = ContestURLBase + chr(65 + countdown - 1)
    return result


if __name__ == '__main__':
    print("Enter contest id:")
    contestID = input()
    contestURLBase = "https://ac.nowcoder.com/acm/contest/" + contestID + "/"
    print("Enter the max problem ID:")
    temp = input()[0]
    if ord('a') <= ord(temp) <= ord('z'):
        temp = chr(ord(temp) + ord('A') - ord('a'))
    contestProblemCount = int(ord(temp) - 65 + 1)

    d = DesiredCapabilities.CHROME
    d['loggingPrefs'] = {'browser': 'ALL', 'performance': 'ALL'}
    options = webdriver.ChromeOptions()
    options.add_experimental_option('perfLoggingPrefs', {
        'enableNetwork': True,
        'enablePage': False,
    })

    browser = webdriver.Chrome( desired_capabilities=d)

    browser.get("https://www.nowcoder.com/login")
    print("\n----------------------------\n" +
          "Press enter after log in...")
    input()

    print("Do you need to download problems? ( press 'y' to continue )")
    if input() == "y":
        print("\n----------------------------\n")
        print("Saving contest info...")
        # Save Problems to file
        savePath = "D:\\PictureSave\\"
        for i in range(1, contestProblemCount + 1):
            print("Saving problem", i, '/', contestProblemCount, '...', sep=' ')
            problemURL = getProblemURL(contestURLBase, i)
            browser.get(problemURL)
            WebDriverWait(browser, 10).until(lambda x: len(x.find_elements_by_class_name("icon-fullscreen")) == 2)
            clickElement = browser.find_elements_by_class_name("icon-fullscreen")[0]
            clickElement.click()
            browser.save_screenshot(savePath + chr(65 - 1 + i) + ".png")

            html = browser.page_source
            soap = BeautifulSoup(html, 'html.parser')
            subject_question = soap.select('#jsCpn_10_layer_0 > div.layer-container-content'
                                           ' > div > div.subject-question')[0]
            subject_describe = soap.select('#jsCpn_10_layer_0 > div.layer-container-content'
                                           ' > div > div.subject-describe')[0]
            outHTML = str(subject_question) + "\n" + str(subject_describe)
            with open(savePath + chr(65 - 1 + i) + ".html", 'w', encoding='utf-8') as f:
                f.write(outHTML)

    # Listening Submission Database
    print("\nListening Submission Database...")
    while True:
        conn = pymysql.connect(user='root', password='2000021177lty', database='judge')
        cursor = conn.cursor()
        query = 'SELECT submit_problem,submit_code,id FROM main WHERE judge_status=0 ORDER BY submit_time LIMIT 1'
        cursor.execute(query)
        problemID = ""
        code = ""
        runID = ""
        for (submit_problem, submit_code, id) in cursor:
            problemID = submit_problem
            code = submit_code
            runID = id
        if code != "":
            print("code=", code)
            browser.get(contestURLBase + problemID)
            WebDriverWait(browser, 10).until(lambda x: x.find_element_by_class_name("CodeMirror-scroll"))
            time.sleep(2)
            resetElement = browser.find_element_by_class_name("js-fresh-code")
            resetElement.click()
            WebDriverWait(browser, 10).until(lambda x: x.find_element_by_class_name("confirm-btn"))
            time.sleep(2)
            commitBtnElement = browser.find_element_by_class_name("confirm-btn")
            commitBtnElement.click()
            codeElement = browser.find_element_by_class_name("CodeMirror-line")
            pyperclip.copy(code)
            codeElement.click()
            ActionChains(browser).key_down(Keys.CONTROL).send_keys('v').key_up(Keys.CONTROL).perform()
            submitButtonElement = browser.find_element_by_id("jsRunCode")
            submitButtonElement.click()

            # Get Submission ID
            logs = browser.get_log('performance')
            for row in logs:
                print(row)

            submissionID = 1
            query = "UPDATE main SET judge_status = 1, judge_remoteid = %s, judge_time = %s WHERE id = %s"
            cursor.execute(query, (submissionID, datetime.datetime.now(), runID))
            conn.commit()
            conn.close()

        time.sleep(3)
