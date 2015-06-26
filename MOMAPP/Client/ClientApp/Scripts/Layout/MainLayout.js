
    $(document).ready(function () {
        // alert(window.sessionStorage.getItem("userName"))
        $("#userName").text("Hello " + window.sessionStorage.getItem("userName"))
        if (window.sessionStorage.getItem("roleId") == 2) {
            $("#admin1").hide();
            $("#admin2").hide();
        }
        else {
            $("#admin1").show();
            $("#admin2").show();
        }
    })
