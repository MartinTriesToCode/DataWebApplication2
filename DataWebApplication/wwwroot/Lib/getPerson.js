function getPersonList() {
        
    $.get("Person/PersonList", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);
        document.getElementById("People").innerHTML = data;
    })  
}