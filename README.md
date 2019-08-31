# Send-Mail-Azure-Function

---

### Table of Content

* [1. Purpose of this project](#1.)
* [2. What I used](#2.)
    * [2.1. Azure Functions](#2.1.)
    * [2.2. C#](#2.2.)
    * [2.3. SendGrid](#2.3.)
    * [2.4. reCAPTCHA](#2.4.)

---

<a name="1."></a>
## 1. Purpose of this project

The goal of this project is to implement a backend service for the contact form of my portfolio which is hosted via Github Pages. It is possible to send me a message via this contact form to my email address which I don't want to share on my page publicly. 

<a name="2."></a>
## 2. What I used

<a name="2.1."></a>
### 2.1. Azure Functions

To Implement the back end features I used the Azure Function as FaaS Provider.

<a name="2.2."></a>
### 2.2. C#

The Project is implemented in C#.

<a name="2.3."></a>
### 2.3. SendGrid

SendGrid is used as an SMTP service.

<a name="2.4."></a>
### 2.4. reCAPTCHA

To protect the email functionality against abuse I implemented Google reCAPTCHA v3. 