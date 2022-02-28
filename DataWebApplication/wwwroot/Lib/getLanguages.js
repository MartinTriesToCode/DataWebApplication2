$(document).ready(function () {

    $("#languages-btn").click(function () {

        var inputid = document.getElementById('person-id').value;

        if (inputid != null && inputid > 0
            && inputid < 1000 && Number.isInteger(parseFloat(inputid))) {
            $.ajax({
                type: "POST",
                url: "/Person/PersonLanguages",
                data: { id: inputid },
                dataType: "JSON",
                success: function (data) {
                    console.log("Data: " + data + "\nStatus: " + status);
                    $("People").empty();
                    document.getElementById('message').innerHTML = data.msg;
                    if (data.msg == "") {
                        getLanguageList(inputid);
                    }
                    else {
                        $("People").empty();
                    }
                },
                error: function () {
                    alert("Error occured!!")
                }
            })
        }
        else {
            $("#People").empty();
            document.getElementById('message').innerHTML = "Invalid ID";
        }
    })
})
