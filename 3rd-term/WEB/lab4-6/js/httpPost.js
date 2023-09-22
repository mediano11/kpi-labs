const shareButtons = document.querySelectorAll('.share-button');
shareButtons.forEach( btn => {
    btn.addEventListener('click', e => {
        e.preventDefault();
        // формуємо об'єкт даних для відправки
        let formData = {
            fullname: fullname.value,
            group: group.value,
            points: results.attributes.value.value
        }
    
        const mode = btn.getAttribute('data-post');
        
        // створюємо запит
        let xhr = new XMLHttpRequest();
        // ініціалізуємо його
        xhr.open('POST', `/${mode}`);
        // встановлюємо заголовки
        xhr.setRequestHeader('Content-Type', 'application/json');
        console.log('sending...')
        // отримуємо і аналізуємо відповідь серевера
        xhr.onload = function () {
            console.log(xhr.responseText);
            if(xhr.responseText == 'success') {
                alert(`${mode === "email" ? "Email" : "Telegram message"} sent successfully`)
            } else {
                alert("Something went wrong!");
            }
        }
        xhr.send(JSON.stringify(formData));
    })
})