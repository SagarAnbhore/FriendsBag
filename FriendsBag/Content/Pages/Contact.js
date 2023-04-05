$(document).ready(function () {
    GetContactList();
});

var SaveContact = function () {
    debugger;
    var firstname = $("#txtfname").val();
    var lastname = $("#txtlname").val();
    var email = $("#txtemail").val();
    var mobileno = $("#txtmobileno").val();
    var message = $("#txtmessage").val();


    var model = { FirstName: firstname, LastName: lastname, Email: email, MobileNo: mobileno, Message: message, };

    $.ajax({
        url: "/Home/SaveContact",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("sucessfully.......");
        }
    });
}

var GetContactList = function () {
    $.ajax({
        url: "/Home/GetContactList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        async: false,
        dataType: "json",
        success: function (response) {
            var html = "";
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id +
                    "</td><td>" + elementValue.FirstName +
                    "</td><td>" + elementValue.LastName +
                    "</td><td>" + elementValue.Email +
                    "</td><td>" + elementValue.MobileNo +
                    "</td><td>" + elementValue.Message + "</td><td><input type='submit' value='delete' onClick='deleteContact(" + elementValue.Id + ")'/></tr></td>"
                    
            });

            $("#tblContact tbody").append(html);
        }
    });
}

var deleteContact = function (Id) {
    var model = { Id: Id };
    $.ajax({
        url: "/Home/deleteContact",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully");
        }
    });
}

        