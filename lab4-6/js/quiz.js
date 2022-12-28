import {getResource, equalAnswerArrays, isAtLeastOneChecked} from "./utility.js";

getResource("questions.json")
    .then((data) => getQuestions(data.questions))
    .then((data) => generateQuiz(data, quizContainer));

let quizContainer = document.getElementById('quiz');

function getQuestions(questions){
    let radioQuestions = [];
    let checkboxQuestions = [];
    let listQuestions = [];
    let textQuestions = [];
    let matchQuestions = [];
    for(let i = 0; i < questions.length; i+=1){
        if(questions[i].typeQuestion==="radio")
            radioQuestions.push(questions[i])
        else if(questions[i].typeQuestion==="checkbox")
            checkboxQuestions.push(questions[i])
        else if(questions[i].typeQuestion==="text")
            textQuestions.push(questions[i])
        else if(questions[i].typeQuestion==="list")
            listQuestions.push(questions[i])
        else if(questions[i].typeQuestion==="match")
            matchQuestions.push(questions[i])
    }
    let newRadioQuestions = getRandomQuestions(radioQuestions,5);
    let newCheckboxQuestions = getRandomQuestions(checkboxQuestions,2);
    let newListQuestions = getRandomQuestions(listQuestions,1);
    let newTextQuestions = getRandomQuestions(textQuestions,1);
    let newMatchQuestions = getRandomQuestions(matchQuestions,1);

    return [...newTextQuestions, ...newRadioQuestions, ...newCheckboxQuestions, ...newListQuestions, ...newMatchQuestions];
}
function getRandomQuestions(arr, n) {
    const shuffled = [...arr].sort(() =>  0.5 - Math.random());
    return shuffled.slice(0,n);
}
function generateQuiz(questions, quizContainer){
    function showTextQuestion(question, i){
        let output = [];
        output.push(
            `<div class="quiz__task task-${i}">
                <h4 class="quiz__question">${i+1}. ${question.question}</h4>
                <div class="quiz__answers" data-type="${question.typeQuestion}">
                    <label><input type="${question.typeQuestion}" name="question-${i}"></label>
                </div>
            </div>`
        );
        return output;
    }
    function showListQuestion(question, i){
        let output = [];
        let answers;
        let taskItem = [];
             
        for(let task in question.tasks){
            answers = [];
            for(let ans in question.tasks[task].answers){
                answers.push(
                    `<option value="${question.tasks[task].answers[ans]}">${question.tasks[task].answers[ans]}</option>`
                );
            }
            
            taskItem.push(
                `
                <div class="quiz__subtask">
                    <label>${question.tasks[task].sentence}</label>
                    <select id="list-${task}" name="question-${i}-${task}"><option hidden>Select one...</option>${answers.join('')}</select> 
                </div>
                `
            )
            
        }

        output.push(
            `
            <div class="quiz__task task-${i}">
                <h4 class="quiz__question">${i+1}. ${question.question}</h4>
                <div class="quiz__answers" data-type=${question.typeQuestion}>${taskItem.join('')}</div>
            </div>`                
        );
        return output;
        
    }
    function showDefaultQuestion(question, i){
        let output = [];
        let answers = [];
            for(let letter in question.answers){

                answers.push(
                    `
                    <li class="answers__item">
                        <input type="${question.typeQuestion}" name="question-${i}" value="${letter}" id="task-${i}-${letter}">
                        <label class="${question.typeQuestion}__label" for="task-${i}-${letter}">${question.answers[letter]}</label>
                    </li>
                    `
                );
            }

            output.push(
                `<div class="quiz__task task-${i}">
                    <h4 class="quiz__question">${i+1}. ${question.question}</h4>
                    <div class="quiz__answers" data-type="${question.typeQuestion}">${answers.join('')}</div>
                </div>`
            );
        return output;
    }
    function showMatchQuestion(question, i) {
        let output = [];
        let definitions = [];
        let answers = [];
        let emptyAnswers = [];
            for(let j = 0; j < question.answers.length; j++){
                answers.push(
                    `<div class="answers__card"
                    data-card="${j}" draggable="true">${question.answers[j]}</div>`
                )
                definitions.push(
                    `<li class="answers__definition">${question.definitions[j]}</li>`
                )
                emptyAnswers.push(
                    `<li class="answers__cell"></li>`
                )
            }

            output.push(
                `<div class="quiz__task task-${i}">
                    <h4 class="quiz__question">${i+1}. ${question.question}</h4>
                    <div class="quiz__answers" data-type="${question.typeQuestion}">
                        <div class="answers__main">
                            <ul class="answers__definitions">${definitions.join('')}</ul>
                            <ul class="answers__meanings answers-container">${emptyAnswers.join('')}</ul>
                        </div>
                        <ul class="answers__box answers-container">${answers.join('')}</ul>
                    </div>
                </div>`
            );
        
        return output;
    }
    function showQuestions(questions, quizContainer){
        let output = [];
       
        for(let i=0; i<questions.length; i++){
            if(questions[i].typeQuestion === "radio" || questions[i].typeQuestion === "checkbox") 
                output.push(showDefaultQuestion(questions[i],i));
            else if(questions[i].typeQuestion === "text"){
                output.push(showTextQuestion(questions[i],i));
            }
            else if(questions[i].typeQuestion === "list")
                output.push(showListQuestion(questions[i], i));
            else if(questions[i].typeQuestion === "match") {
                output.push(showMatchQuestion(questions[i], i));
                            
            }
        
        quizContainer.innerHTML = output.join('');
        
        }
        const resultsBtn = document.createElement("button");
        resultsBtn.textContent= "Get results"
        resultsBtn.classList.add('quiz__btn', 'btn');
        resultsBtn.setAttribute("id", "submit");
        resultsBtn.addEventListener("click", (e)  => {
            e.preventDefault();
            showResults(questions, quizContainer);
        });
        quizContainer.appendChild(resultsBtn);
    }
    showQuestions(questions, quizContainer);
    dragAndDrop();    

    function countPoints(userAnswer, correctAnswer, container, increment = 1){
        let points = 0;
        if(userAnswer===correctAnswer){
            points += increment;
            container.style.color = 'lightgreen';
        }
        else{
            container.style.color = 'red';
        }
        return points;
    }
    function countRadioQuestion(question, answer, i){
        let userAnswer = (answer.querySelector(`input[name=question-${i}]:checked`)||{}).value;
        return countPoints(userAnswer, question.correctAnswer, answer);
    }
    function countCheckBoxQuestion(question, answer, i){
        let points = 0;
        let userAnswer = Array.from(document.querySelectorAll(`input[name=question-${i}]:checked`));
        if(equalAnswerArrays(userAnswer, question.correctAnswer)){
            points++;
            answer.style.color = 'lightgreen';
        }
        else{
            answer.style.color = 'red';
        } 
        return points;
    }
    function countListQuestion(question, answer, i){
        let points = 0;
        for(let task = 0; task < question.tasks.length; task++) {
            let userAnswer = (answer.querySelector(`select[name=question-${i}-${task}]`)||{}).value;
            points += countPoints(userAnswer, question.tasks[task].correctAnswer,answer.children[task], 0.5);
        };        
        return points;
    }
    function countTextQuestion(question, answer, i){
        let answerInput = (answer.querySelector(`input[name=question-${i}]`)||{});
        return countPoints(answerInput.value, question.correctAnswer, answerInput);
    }
    function countMatchQuestion(question, answer, i){
        let points = 0;
        let userAnswers = answer.querySelector(".answers__meanings");
        let definitions = answer.querySelector(".answers__definitions");
        for(let j = 0; j < userAnswers.children.length; j++) {
            let userAnswer = userAnswers.children[j];
            let definition = definitions.children[j];
            points += countPoints(userAnswer.textContent, question.correctAnswers[definition.textContent], userAnswer, 1/3);
        };        
        return points;
    }
    function countResults(answerContainers){
        let mark = 0;
        for(let i=0; i<answerContainers.length; i++){
            if(answerContainers[i].getAttribute('data-type')==="radio"){
                mark += countRadioQuestion(questions[i],answerContainers[i],i);
            } else if(answerContainers[i].getAttribute('data-type')=="checkbox"){
                mark += countCheckBoxQuestion(questions[i],answerContainers[i],i);
            } else if(answerContainers[i].getAttribute('data-type')=="list") {
                mark += countListQuestion(questions[i],answerContainers[i],i);
            } else if(answerContainers[i].getAttribute('data-type')=="text") {
                mark += countTextQuestion(questions[i],answerContainers[i],i);
            } else if(answerContainers[i].getAttribute('data-type')=="match") {
                mark += countMatchQuestion(questions[i],answerContainers[i],i);
            }
        }
        return mark;
    }
    function showResults(questions, quizContainer){
        let answerContainers = quizContainer.querySelectorAll('.quiz__answers');
        let results = document.getElementById("results");
        
        if(checkValidity(quizContainer)){
            let mark = countResults(answerContainers);
            results.setAttribute("value", mark.toFixed(2));
            results.textContent = `You get ${mark.toFixed(2)} out of ${questions.length} points`;
            document.querySelector("#results").style.display="flex";
            document.querySelector(".share").style.display="flex";  
        }  
    }

    function checkError(userAnswer, isError, container, message){
        if(!userAnswer){
            if(!isError) {
                const error = document.createElement("div");
                error.classList.add("error");
                error.textContent = message;
                container.appendChild(error)
            }
        }  else {
            if(isError){
                const errorItem = container.querySelector(".error");
                container.removeChild(errorItem)
            }
        }
    }

    function checkTextValidation(answer,i) {
    let userAnswer = (answer.querySelector(`input[name=question-${i}]`)).value !== "";
        const isError = Array.from(answer.children).some(child => child.classList.contains("error"));
        checkError(userAnswer,isError, answer, "Write your answer");
    }
    function checkRadioValidation(answer,i) {
        let userAnswer = (answer.querySelector(`input[name=question-${i}]:checked`));
        const isError = Array.from(answer.children).some(child => child.classList.contains("error"));
        checkError(userAnswer,isError, answer, "Please, choose one option");
    }
    function checkListValidation(answer,i) {
        for(let task = 0; task < answer.children.length; task++) {
            let userAnswer = (answer.querySelector(`select[name=question-${i}-${task}]`)).value !== "Select one...";
            const isError = Array.from(answer.children[task].children).some(child => child.classList.contains("error"));
            checkError(userAnswer,isError, answer.children[task], "Please, choose one option")
        };  
    }
    function checkCheckboxValidation(answer,i) {
        let userAnswer = isAtLeastOneChecked(`question-${i}`)
        const isError = Array.from(answer.children).some(child => child.classList.contains("error"));
        checkError(userAnswer,isError, answer, "Please, choose at least one option")
    }
    function checkMatchValidation(answer,i) {
        let userAnswers = answer.querySelector(".answers__meanings");
        for(let j = 0; j < userAnswers.children.length; j++) {
            let userAnswer = userAnswers.children[j].textContent !== "";
            const isError = Array.from(answer.children).some(child => child.classList.contains("error"));
            checkError(userAnswer,isError, userAnswers.children[j], "Please, match the pairs");
        };       
    }
    function checkValidity(quizContainer) {
        let answerContainers = quizContainer.querySelectorAll('.quiz__answers');
        for(let i=0; i<answerContainers.length; i++){
            if(answerContainers[i].getAttribute('data-type')==="radio"){
                checkRadioValidation(answerContainers[i],i);
            } else if(answerContainers[i].getAttribute('data-type')=="checkbox"){
                checkCheckboxValidation(answerContainers[i],i);
            } else if(answerContainers[i].getAttribute('data-type')=="list") {
                checkListValidation(answerContainers[i],i);
            } else if(answerContainers[i].getAttribute('data-type')=="text") {
                checkTextValidation(answerContainers[i],i);
            } else if(answerContainers[i].getAttribute('data-type')=="match") {
                checkMatchValidation(answerContainers[i],i);
            }
           
        }
        let invalidElement = document.getElementsByClassName('error')[0];
        if(invalidElement) {
            invalidElement.setAttribute('tabindex', '-1')
            invalidElement.focus()
            invalidElement.removeAttribute('tabindex')
        }
        
        return !quizContainer.contains(invalidElement) // if doesn't exist - then there is no error
    }
}



const dragAndDrop = () => {
    const draggables = document.querySelectorAll(".answers__card");
    const containers = document.querySelectorAll(".answers-container");

    draggables.forEach( draggable => {
        draggable.addEventListener("dragstart", ()=> {
            draggable.classList.add("dragging");
        });
        draggable.addEventListener("dragend", ()=> {
            draggable.classList.remove("dragging");
        });
    });

    containers.forEach(container => {
        container.addEventListener("dragover", (e)=> {
            e.preventDefault();
            const draggable = document.querySelector(".dragging");
            const parentContainer = document.querySelector(".answers__meanings");
            if(parentContainer.childElementCount>3) {
                parentContainer.removeChild(parentContainer.querySelector(".answers__cell:last-of-type"))
            }
            else if(parentContainer.childElementCount<3) {
                let emptyCell = document.createElement("li");
                emptyCell.classList.add("answers__cell");
                parentContainer.appendChild(emptyCell);
            } 
            const afterElement = getDragAfterElement(container, e.clientY);
            if(afterElement == null){
                container.appendChild(draggable);
            } else {
                container.insertBefore(draggable, afterElement);
            }
        });
    });

    function getDragAfterElement(container, y) {
        const draggableElements = [...container.querySelectorAll(".answers__card:not(.dragging)"),
        ...container.querySelectorAll(".answers__cell:not(.dragging)")]

        return draggableElements.reduce((closest, child) => {
            const box = child.getBoundingClientRect();
            const offset = y - box.top - box.height / 2;
            if(offset < 0 && offset > closest.offset) {
                return {offset: offset, element: child}
            } else {
                return closest
            }
        }, { offset: Number.NEGATIVE_INFINITY}).element;
    }
}
