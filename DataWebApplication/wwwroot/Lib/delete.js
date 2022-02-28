

$(document).ready(function () {
    
    $("#delete-btn").click(function () {
       
        var inputid = document.getElementById('person-id').value;
      
        if (inputid != null && inputid > 0
            && inputid < 1000 && Number.isInteger(parseFloat(inputid))) {
            $.ajax({
                type: "POST",
                url: "/Person/PersonDelete",
                data: { id: inputid },
                dataType: "JSON",
                success: function (data) {
                    console.log("Data: " + data + "\nStatus: " + status);
                    $("People").empty();
                    document.getElementById('message').innerHTML = data.msg;
                    getPersonList();
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