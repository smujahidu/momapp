
        $(document).ready(function () {

            $("#messageBody").Editor()
            $("#datepicker").datepicker();
            
            $.ajax({
                type: "POST",
                url: "http://localhost:50933/api/Mom/Getproject",
                crossDomain: true,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'text/plain'
                },
                //contentType: "application/json; charset=utf-8",
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


            $("#btn").click(function () {
                //var Subject1 = $("#sub").val();
                //var Description1 = $("#description").val();
                //var json = {}
                //json.Subject = Subject1
                //json.Description = Description1
                //var source = {
                //    'Subject': $("#sub").val(),
                //    'Description': $("#description").val()
                //}

                var detail = {
                    ProjectID: $("#ddlProject").val(),
                    CreationDate: $("#datepicker").val(),
                    Subject: $("#subject").val(),
                    Description: $("#MailmessageBody").text()
                }

                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "http://localhost:50933/api/Mom/Savemom",
                    data: JSON.stringify(detail),
                    success: function (data) {
                        window.location.href = "CreateDoc";
                    },
                    error: function (error) {
                        jsonValue = jQuery.parseJSON(error.responseText);

                    }
                });
            });


            $("#ddlProject").on('change', function () {
                $("#List").empty();
                var id = $(this).val();
                //alert(id);
                $.ajax({
                    type: 'POST',
                    url: "http://localhost:50933/api/Mom/Getlist?id=" + id,
                    //contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        // alert(JSON.stringify(data))
                        if (data != null) {

                            var strResult = "<table><th>EmployeeList</th>";
                            for (var i = 0; i < data.length; i++) {
                                //strResult += "<tr><td>" + data[i].UserName + "</td></tr> </br>"
                                //strResult += "</table>";
                                //$("#divresult").html(strResult);

                                $("#List").append(
                         $('<option/>', {
                             // value: data[i].ProjectID,
                             text: data[i].UserName
                         })
                     );
                            }

                        }
                    },
                    error: function (msg) {
                        alert(msg.nodata);
                    }
                });
            });


        });

