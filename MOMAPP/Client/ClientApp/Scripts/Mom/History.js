       $(document).ready(function () {

           $("#Description").Editor()
           $("#datepicker").datepicker();
           $("#divMom").hide();

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

           $("#btnSearch").click(function () {
               $("#divMom").show();
               
               var detail = {
                   ProjectID: $("#ddlProject").val(),
                   CreationDate: $("#datepicker").val()
               }

               $.ajax({
                   type: "POST",
                   url: "http://localhost:50933/api/Mom/Getmom",
                   headers: {
                       'Accept': 'application/json',
                       'Content-Type':'text/plain'
                   },
                   //ContentType: 'application/json; charset=utf-8',
                   //dataType: json,
                   data:JSON.stringify(detail),
                   success: function (data) {
                       
                       $("#subject").val(data.Subject)
                       $("#Description").val(data.Description)
                   },
                   error: function () { alert("error");}
               });
           })

       });

