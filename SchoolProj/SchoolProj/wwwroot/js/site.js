// Добавить комментарий

function addComment(){
    
    let commentInput = $("#commentInput")
    let commentText = commentInput.val();
    
    if (commentText.length < 1) {
        alert('Комментарий не может быть пустым!');
        return;
    }

    let path = document.location
    let courseId = /\d+#?$/g.exec(path)[0]

    // TODO отправлять id пользователя
    
    $.ajax({
        type: 'POST',
        url: '/add_comment',
        headers: {
            'course_id': courseId,
            'comment_text': encodeURIComponent(commentText),
        },
        //data: stringified,
        // success: function(res, status, xhr) {
        // 	let id = xhr.getResponseHeader("id")
        // 	let result = xhr.getResponseHeader("status")
        // 	if (result === "success")
        // 		document.location.href = "/debate/"+id
        // }
    })
    
    let dateTime = new Date().toLocaleString("ru").slice(0, -3).replace(',', '');

    // TODO получить логин пользователя
    
    let newComment = "<div class=\"comment-block\">" +
                        "<div class=\"comment-text\">" + commentText + "</div>" +
                        "<div class=\"comment-user\">" + "ЛОГИН" + "</div>" +
                        "<div class=\"comment-date\">" + dateTime + "</div>" +
                    "</div>";
    
    let comments = $("#comments");
    comments.prepend(newComment);
    
    // TODO изменить в БД date на timestamp

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
        url: '/signin_user',
        headers: {
            'name': name,
            'password': password,
            'remember': remember
        },
        success: function(res, status, xhr) {
            let result = xhr.getResponseHeader("signin_result")
            if (result === "ok")
                document.location.href = "Account"
            else
                alert("Неверный логин или пароль")
        }
    })
}
