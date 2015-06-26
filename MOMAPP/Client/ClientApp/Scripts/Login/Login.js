 
    $(document).ready(function () {
        $("#btn-login").click(function () {
           
            var user = {
                UserName: $('#login-username').val(),
                Password: $('#login-password').val()
            }
                
                
            debugger;
            $.ajax({
                url: 'http://localhost:50933/api/Login/login',
                type: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'text/plain'
                },
                //contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: JSON.stringify(user),
                success: function (data) {
                    //Session["userName"] = data.UserName;
                    //alert(Session["userName"])
                    window.sessionStorage.setItem("userName", data.UserName)
                    window.sessionStorage.setItem("roleId", data.RoleID)
                    if(data.RoleID==1)
                        window.location.href = "http://localhost:58405/Admin/Index";
                    else if(data.RoleID==2)
                        window.location.href = "http://localhost:58405/Mom/Index";
                    else
                        alert("Invalid User Name/Password")
                        
                },
                error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }
            });
        });
           



    });