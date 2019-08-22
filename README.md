# Send-Mail-Azure-Function

---

### Table of Content

* [1. Purpose of this project](#1.-Purpose-of-this-project)
* [2. What I used](#2.-What-I-used)
    * [2.1. Azure Functions](#2.1.-Azure-Functions)
    * [2.2. C#](#2.2.-C#)
    * [2.3. SendGrid](#2.3.-SendGrid)
    * [2.4. reCAPTCHA](#2.4.-reCAPTCHA)

---

## 1. Purpose of this project

The goal of this Project is to implement an Backend Service for the Contact form of my portfolie which is hosted via Github Pages. It is possible to send me message via this portfolio page contact form to my email address which I don't want to share on my page publicly.

## 2. What I used

### 2.1. Azure Functions

To Implement the back end features I used the Azure Function as FaaS Provider.

### 2.2. C#

The Project is Implemented in C#.

### 2.3. SendGrid

SendGrid is used as a SMTP service.

### 2.4. reCAPTCHA

To protect the email functionality against abuse I implemented Google reCapatcha v3. 