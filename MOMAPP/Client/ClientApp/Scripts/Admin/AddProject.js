
    $(document).ready(function () {
        $("#datepicker").datepicker();

        $("#btnSave").click(function () {
            jQuery.support.cors = true;
            var projdetails = {
                ProjectName: $('#txtaddEmpName').val(),
                StartDate: $('#datepicker').val(),
                Status: $('#ddlStatus').val()
            };
         
            $.ajax({
                url: 'http://localhost:50933/api/Admin/SaveProject',
                type: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'text/plain'
                },

                data: JSON.stringify(projdetails),
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    alert("Project Record Inserted Successfully");
                },

            });
        });
    });
