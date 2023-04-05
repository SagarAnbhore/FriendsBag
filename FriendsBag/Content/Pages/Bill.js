$(document).ready(function () {
    GetBillList();
});

var SaveBill = function () {
    debugger;
    var Bill_Id = $("#hdnId").val();
    var customer_name = $("#txtcname").val();
    var item_name = $("#txtitemname").val();
    var quantity = $("#txtquantity").val();
    var amount = $("#txtamount").val();
    var total_amount = $("#txttotalamount").val();
    var invoice_no = $("#txtinvoiceno").val();
    var date = $("#txtdate").val();
    var payment_mode = $("#txtpaymentmode").val();



    var model = { Customer_Name: customer_name, Item_Name: item_name, Quantity: quantity, Amount: amount, Total_Amount: total_amount, Invoice_No: invoice_no, Date: date, Payment_Mode: payment_mode, };

    $.ajax({
        url: "/Bill/SaveBill",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("sucessfully.......");
        }
    });
}
var GetBillList = function () {
   $.ajax({
            url: "/Bill/GetBillList",
            method: "post",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                var html = "";
                $.each(response.model, function (index, elementValue) {
                    html += "<tr><td>" + elementValue.Bill_Id +
                        "</td><td>" + elementValue.Customer_Name +
                        "</td><td>" + elementValue.Item_Name +
                        "</td><td>" + elementValue.Quantity +
                        "</td><td>" + elementValue.Amount +
                        "</td><td>" + elementValue.Total_Amount +
                        "</td><td>" + elementValue.Invoice_No +
                        "</td><td>" + elementValue.Date +
                        "</td><td>" + elementValue.Payment_Mode + "</td><td><input type='submit' value='Edit'class='btn btn-danger' onClick='EditBill(" + elementValue.Bill_Id + ")'/></td></tr>";

                       
                });

                $("#tblBill tbody").append(html);
            }
   });
}

var EditBill = function (Bill_Id) {
    var model = { Bill_Id: Bill_Id };
    $.ajax({

        url: "/Bill/EditBill",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnId").val(response.model.Bill_Id);
            $("#txtcname").val(response.model.Customer_Name);
            $("#txtitemname").val(response.model.Item_Name);
            $("#txtquantity").val(response.model.Quantity);
            $("#txtamount").val(response.model.Amount);
            $("#txttotalamount").val(response.model.Total_Amount);
            $("#txtinvoiceno").val(response.model.Invoice_No);
            $("#txtdate").val(response.model.Date);
            $("#txtpaymentmode").val(response.model.Payment_Mode);

        }
    });
}
