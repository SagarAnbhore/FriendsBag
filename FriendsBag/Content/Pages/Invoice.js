$(document).ready(function () {
    GetInvoiceList();
})
var SaveInvoice = function () {
    debugger
    var customer_id = $("#txtId").val();
    var item_name = $("#txtItemName").val();
    var amout = $("#txtAmout").val();
    var discount = $("#txtDiscount").val();
    var quntity = $("#txtQuntity").val();
    var total_amount = $("#txtAmount").val();
    var invoice_date = $("#txtDate").val();
    var payment_mode = $("#txtMode").val();
    var igst = $("#txtIGST").val();
    var cgst = $("#txtCGST").val();
    var sgst = $("#txtSGST").val();

    var model = {
        Customer_Id: customer_id, Item_Name: item_name, Amout: amout, Discount: discount, Quntity: quntity, Total_Amount: total_amount, Invoice_Date: invoice_date, Payment_Mode: payment_mode, IGST: igst, CGST: cgst, SGST: sgst,
    };

    $.ajax({
        url: "/Invoice/SaveInvoice",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Succesfuly...");
        }
    });
}

var GetInvoiceList = function () {
    $.ajax({
        url: "/Invoice/GetInvoiceList",
        method: "Post",
        contentType: "application/json;charset=utf-8",
        async: false,
        dataType: "json",      
        success: function (response) {
            var html = "";
            $("#tbiInvoice tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Invoice_Id +
                    "</td><td>" + elementValue.Customer_Id +
                    "</td><td>" + elementValue.Item_Name +
                    "</td><td>" + elementValue.Amout +
                    "</td><td>" + elementValue.Discount +
                    "</td><td>" + elementValue.Quntity +
                    "</td><td>" + elementValue.Total_Amount +
                    "</td><td>" + elementValue.Invoice_Date +
                    "</td><td>" + elementValue.Payment_Mode +
                    "</td><td>" + elementValue.IGST +
                    "</td><td>" + elementValue.CGST +
                    "</td><td>" + elementValue.SGST + "</td></tr>"
            });
            $("#tbiInvoice tbody").append(html);
        }
    });

}
