$(document).ready(function () {
    GetItemddl();
});

var SaveOrder = function () {
    var invoicid = $("#txtId").val();
    var name = $("#txtName").val();
    var mobileno = $("#txtMobileNo").val();
    var address = $("#txtAddress").val();
    var city = $("#txtCity").val();
    var colour = $("#txtColour").val();
    var price = $("#txtPrice").val();
    var paymentmode = $("#txtPaymentMode").val();
    var deliverydate = $("#txtDeliveryDate").val();
    var totalamount = $("#txtTotalAmount").val();
    var ordernotes = $("#txtOrderNotes").val();
    var item = $("#txtItem").val();

    var model = {
        Invoicid: invoicid, Name: name, MobileNo: mobileno, Address: address, City: city, colour: colour, Price: price, PaymentMode: paymentmode, DeliveryData: deliverydate, TotalAmount: totalamount, OrderNotes: ordernotes, Item: item,
    };

    $.ajax({
        url: "/Order/SaveOrder",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("succesfuly..");
        }
    });
}
var GetItemddl = function () {
    $.ajax({
        url: "/Item/GetItemddl",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#ddlItem").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<option value=" + elementValue.Id + ">" + elementValue.ItemName + "</option>";
            });
            $("#ddlItem").append(html);
        }
    })
}