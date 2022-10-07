$(document).ready(
    function () {
        $('#submit').click(function () {


            $.ajax({
                url: 'http://localhost:20814/Users/authenticate',
                dataType: 'json',
                type: 'post',
                contentType: 'application/json',
                data: JSON.stringify({
                    username: $('#Username').val(),
                    password: $('#Password').val()
                }),
                processData: false,
                success: function (data) {
                    console.log(data);
                    alert("Login Credential authenticated successfully")
                     
                    if (data.role == "Manager") {
                        window.location.replace('http://localhost:20814/managerhome?name=' + data.name)
                    }
                    else {
                        window.location.replace('http://localhost:20814/WFMangerHome')
                    }
                },
                error: function () {
                    alert("Authentication Failed")
                }
            });



        })

    }
)