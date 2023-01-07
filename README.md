
# AvaTrade Tests Automation
<img src="https://user-images.githubusercontent.com/107935566/211152452-122bf0d5-27ba-4d11-b3c0-c0ef79e02035.png">

## Requirments : 
#### 1- clone this repositiry
#### 2- open folder "AvaTrade_Tests_Automation"

#### 3- click on TestCase1.cs
#### 4- download Visual Studio
#### 5- right click on Solution on right side
#### 6- click on Manage NUnit packages
#### 7- install packages
 ###### a- NUnit
 ###### b- NUnitTestAdapter
 ###### c- Selenium.WebDriver
 ###### d- Selenium.Support
 
 ## Test Case 1 :
   This test goes to the www.avatrade.com website
 Clicks on the login button.
 Enters the email and password in the appropriate fields and clicks SUBMIT
(Sometimes, the website's system detects the automation process and tries to prevent it by displaying a button that needs to be pressed and held as some kind of Captcha to make sure “a human is using it”)
Navigates to the login page 
After logging in, the test validates that the username used to login is indeed the relevant one, by checking the name after the word WELCOME, in this example it checks if it’s “rami”   

 [![TC001]https://user-images.githubusercontent.com/107935566/211153513-272fc919-67df-45d6-9a3d-239890c3276d.png](https://user-images.githubusercontent.com/107935566/211153272-4fa2d810-4248-4a21-9ad7-8d33c10393d7.mp4)
 
 
  ## Test Case 2 :
 This test goes to the www.avatrade.com website and clicks on one of the trading lists
 Compares the values of the sections high/low, and checks if the value of the section “high”
 is indeed greater than the value “low”
 *As highlighted in the photo below*
 <img src="https://user-images.githubusercontent.com/107935566/211154717-e04a75e6-4dfe-458b-9199-18e40cd65ad8.jpg">
 
 There is also in function that allows the user to choose in which trade he wants to compare the high-low values. The user can do so by counting from top to bottom in   ascending order to choose the trade he wants for example, If the user wants to compare the high/low sections of Tesla’s trade, he clicks “5” 
 <img src="https://user-images.githubusercontent.com/107935566/211154788-dac1ffe6-fe0a-415c-8818-d78285dca805.jpg">
 
 [![TC002]](https://user-images.githubusercontent.com/107935566/211154412-9b8430ca-5180-462d-b872-969b7876ade3.mp4)
 
 
  ## Test Case 3 :
 The test clicks on the “Hamburger menu”
 Navigates to the search field, types “what is forex”
 Clicks on the first result, after the page loads,
 compares that the title of this page is indeed the one searched for.
 <img src="https://user-images.githubusercontent.com/107935566/211155570-9122cee3-5867-41ee-9413-c98bd53a98af.jpg">
 


 [![TC003]](https://user-images.githubusercontent.com/107935566/211154951-8173595a-65db-439e-ac87-f2f6fd9846cd.mp4)
 

