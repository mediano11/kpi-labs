require("dotenv").config();
const express = require("express");
const nodeMail = require("nodemailer");
const TelegramBot = require('node-telegram-bot-api');

const path = require("path");
const port = 5000;
const app = express();

app.use(express.json()) // для аналізу вхідних запитів JSON
app.use(express.static(path.join(__dirname, "/")));

const token = process.env.BOT_TOKEN;
const bot = new TelegramBot(token, {polling: true});

app.post("/telegram", (req, res, next) => {
  const { fullname, group, points} = req.body;

  bot.sendMessage(process.env.CHAT_ID,`\t<b>JS/Canvas test</b>\nStudent: ${fullname}\nGroup: ${group}\nResult: ${points}/10`, {parse_mode: "HTML"})
    .then( () => {  // if fulfilled 
      res.send("success");
    }, (error)=> { // if rejected
      // console.log(error);
        res.send("Message Could not be Sent");
    })
});


app.post("/email", (req, res, next) => {
  const { fullname, group, points} = req.body;

  const transporter = nodeMail.createTransport({
    service: "gmail",
    auth: {
      user: process.env.GMAIL_USER,
      pass: process.env.PASSWORD,
    },
  });
  const mailOption = {
      from: process.env.GMAIL_USER,
      to: "webkpi21@gmail.com",
      subject: "JS/Canvas quiz results",
      html: `<p style="font-size:22px">Hi, <i>${fullname}</i> from <i>${group}</i>. You just passed the JS/Canvas test. Here is the result.</p><p style="font-size:30px; color: coral"><b>\t\tPoints: ${points}/10</b></p>`,
  };
  transporter.sendMail(mailOption, (error, info) => {
    if(error) {
      console.log(error);
      res.send('error');
    }
    else {
      console.log(`Email sent ${info.response}`);
      res.send("success")
    }
  });
});

app.get("/", (req, res) => {
  res.render(index.html);
});

app.listen(port, () => console.log("Server is running!"));