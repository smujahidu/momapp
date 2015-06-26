
$(document).ready(function () {
    $('#uname').val('')
    $('#pwd').val('')
            debugger;
            $.ajax({
                url: 'http://localhost:50933/api/Admin/GetRole',
                type: 'POST',
                crossDomain: true, // enable this
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'text/plain'
                },
                //contentType: "application/json; charset=utf-8",
                dataType: 'json',
                //data: '{}',

                success: function (data) {
                    var result = data;

                    $("#ddlRole").append(
                            $('<option/>', {
                                value: 0,
                                text: "select"
                            })
                        );
                    for (var i = 0; i < result.length; i++) {
                        $("#ddlRole").append(
                            $('<option/>', {
                                value: result[i].RoleID,
                                text: result[i].RoleName
                            })
                        );
                    }
                    //$.each(result, function () {
                    //    alert(resultRoleID );
                    //    $("#ddlRole").append(
                    //        $('<option/>', {
                    //            value: this.RoleID,
                    //            text: this.RoleName
                    //        })
                    //    );
                    //});
                },
                error: function ajaxError(response) {
                    alert(response.status + ' ' + response.statusText);
                }
            });

            //Code For Project
            $.ajax({
                type: "POST",
                url: "http://localhost:50933/api/Mom/Getproject",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'text/plain'
                },
                dataType: 'json',
                success: function (data) {
                    var result = data;
                    // alert(result.length);
                    $("#ddlProject").append(
                           $('<option/>', {
                               value: 0,
                               text: "select"
                           })
                       );
                    for (var i = 0; i < data.length; i++) {
                        $("#ddlProject").append(
                            $('<option/>', {
                                value: data[i].ProjectID,
                                text: data[i].ProjectName
                            })
                        );
                    }
                }
            });

            $("#btnSave").click(function () {
                jQuery.support.cors = true;
                var User = {
                    UserName: $('#uname').val(),
                    Password: $('#pwd').val(),
                    Email: $('#email').val()
                };
                
                $.ajax({
                    url: 'http://localhost:50933/api/Admin/SaveUser',
                    type: 'POST',

                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'text/plain'
                    },

                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(User),
                    success: function (data) {
                        alert("User Record Inserted Successfully");
                    },
                });
            });
        });
