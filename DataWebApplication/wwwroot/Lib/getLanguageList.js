function getLanguageList(personid) {

    $.get("Person/LanguageList", { Id: personid }, function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);
        document.getElementById("People").innerHTML = data;
    })
}