// Добавить комментарий
function addComment() {
    
    let commentInput = $("#commentInput");
    let commentText = commentInput.val();
    
    if (commentText.length < 1) {
        alert('Комментарий не может быть пустым!');
        return;
    }

    let path = document.location;
    let courseId = /\d+#?$/g.exec(path)[0];
    
    $.ajax({
        type: 'POST',
        url: '/add_comment',
        headers: {
            'course_id': courseId,
            'comment_text': encodeURIComponent(commentText),
        },
        success: function(res, status, xhr) {
            let result = xhr.getResponseHeader("result")
            if (result === "ok") {
                let userName = xhr.getResponseHeader("users_name");
                generateNewComment(commentText, userName);
            }
            else
                alert("Что-то пошло не так");
        }
    })
    
    function generateNewComment(commentText, userName) {
        
        let dateTime = new Date().toLocaleString("ru").slice(0, -3).replace(',', '');

        let newComment = "<div class=\"comment-block\">" +
            "<div class=\"comment-text\">" + commentText + "</div>" +
            "<div class=\"comment-user\">" + userName + "</div>" +
            "<div class=\"comment-date\">" + dateTime + "</div>" +
            "</div>";

        let comments = $("#comments");
        comments.prepend(newComment);
    }
    
    commentInput.val("");
}


// Вход
function signin() {
    let form = document.signIn;
    let name = form.name.value;
    let password = form.password.value;
    let remember = form.remember.checked;
    
    if (name.length < 1 || password.length < 1){
        alert("Заполните все поля");
        return;
    }
    
    // TODO запомнить меня
    
    $.ajax({
        type: 'POST',
        url: '/authorization',
        headers: {
            'name': name,
            'password': password,
            'remember': remember,
            'new_user': 'false'
        },
        success: function(res, status, xhr) {
            let result = xhr.getResponseHeader("result")
            if (result === "ok")
                document.location.href = "Account"
            else
                alert("Неверный логин или пароль")
        }
    })
}


// Регистрация
function signup() {
    let form = document.signUp;
    let name = form.name.value;
    let password1 = form.password1.value;
    let password2 = form.password2.value;
    
    let checkName = /^[a-zA-Zа-яёА-ЯЁ]{3,20}$/.test(name);
    let checkPassword = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$/.test(password1);

    if (name.length < 1 || password1.length < 1|| password2.length < 1) {
        alert("Заполните все поля");
        return;
    }
    if (!checkName) {
        alert('Логин должен сожержать минимум 3 символа и состоять только из букв!')
        return;
    }
    if (!checkPassword) {
        alert('Пароль слишком пройстой!' +
            '\nОн должен состоять минимум из 6 символов' +
            '\nи содержать минимум одну цифру, одну заглавную и одну строчную буквы.' +
            '\n(только латинские буквы');
        return;
    }
    if (password2 !== password1) {
        alert("Пароли не совпадают!")
        return;
    }

    $.ajax({
        type: 'POST',
        url: '/authorization',
        headers: {
            'name': name,
            'password': password1,
            'new_user': 'true'
        },
        success: function(res, status, xhr) {
            let result = xhr.getResponseHeader("result")
            if (result === "ok")
                document.location.href = "Account"
            else if (result === "error")
                alert("Произошла ошибка при регистрации. Провертье введенные данные")
            else
                alert("Этот логин уже занят")
        }
    })
}


//Выход
function exit() {
    $.ajax({
        type: 'POST',
        url: '/exit',
        headers: {
            'exit': 'exit'
        },
        success: function(res, status, xhr) {
            let result = xhr.getResponseHeader("result")
            if (result === "ok")
                document.location.href = "SignIn"
            else
                alert("Что-то пошло не так")
        }
    })
}


// Купить курс
function buyCourse() {
    
    let path = document.location;
    let courseId = /\d+#?$/g.exec(path)[0];
    
    $.ajax({
        type: 'POST',
        url: '/buyCourse',
        headers: {
            'course_id': courseId
        },
        success: function(res, status, xhr) {
            let result = xhr.getResponseHeader("result")
            if (result === "ok")
                document.location.reload();
            else
                alert("Что-то пошло не так");
        }
    })
}


// Загрузить файл
function addFile() {
    let input = document.getElementById("file_input");
    let file = input.files[0];
    
    let formData = new FormData();
    formData.append('file', file, file.name);
    
    let xhr = new XMLHttpRequest();

    xhr.open('POST', '/load_file');
    xhr.send(formData);
    
    xhr.onload = function () {
        if (xhr.status === 200) {
            document.location.reload();
        }
    }

}


// Поиск файла
function searchFile() {
    let table = document.querySelector('table');
    let search = document.getElementById('search-text');
    let phrase = search.value.toUpperCase();

    for (let i = 1; i < table.rows.length; i++) {
        if (table.rows[i].cells[1].innerHTML.toUpperCase().indexOf(phrase) > -1) {
            table.rows[i].style.display = "";
        } else {
            table.rows[i].style.display = "none";
        }
    }
}