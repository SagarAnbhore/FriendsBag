$(document).ready(function () {
    GetItemList();
});

var SaveItem = function () {
    $formData = new FormData();
    var image = document.getElementById('Fileselect');
    if (image.files.length > 0) {
        for (var i = 0; i < image.files.length; i++) {
            $formData.append('File-' + i, image.files[i]);

        }
    }
    var itemname = $("#txtItemN").val();
    var itemprice = $("#txtItemP").val();
    var discount = $("#txtDiscout").val();
    var gender = $("#txtGender").val();
    var colour = $("#txtColour").val();
    var description = $("#txtDescription").val();
    var date = $("#txtDate").val();
    var image = $("#Fileselect").val();

    var model = {
        Itemname: itemname, Itemprice: itemprice, Discount: discount, Gender: gender, Colour: colour, Description: description, Date: date, Image: image,
    };
    $formData.append('Image', image);
    $formData.append('Itemname', itemname);
    $formData.append('Itemprice', itemprice);
    $formData.append('Discount', discount);
    $formData.append('Gender', gender);
    $formData.append('Colour', colour);
    $formData.append('Description', description);
    $formData.append('Date', date);

    $.ajax({
        url: "/Item/SaveItem",
        method: "Post",
        data: $formData,
        contentType: "application/json;charset=utf-8",
        contentType: false,
        processData: false,
        success: function (response) {
            alert("Successfull");
            GetItemList();

        }
    })
    
}

var GetItemList = function () {
    $.ajax({
        url: "/Item/GetItemList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: "false",
        success: function (response) {
            var html = "";
            $("#tblItem tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id +
                    "</td><td>" + elementValue.ItemName +
                    "</td><td>" + elementValue.ItemPrice +
                    "</td><td>" + elementValue.Discount +
                    "</td><td>" + elementValue.Gender +                   
                    "</td><td>" + elementValue.Colour +
                    "</td><td>" + elementValue.Description +
                    "</td><td>" + elementValue.Date +
                   "</td><td><img src='../Content/img/" + elementValue.Image + "' style='max-widht:400px;max-height:200px;'/></td><td>" + 
                    "</td ></tr > ";
            });
            $("#tblItem tbody").append(html);
        }
    });

}

//var saveItem = function () {
//    $formData = new FormData();
//    var image = document.getElementById('Fileselect');
//    if (image.files.length > 0) {
//        for (var i = 0; i < image.files.length; i++) {
//            $formData.append('File-' + i, image.files[i]);

//        }
//    }

//    var image = $("#Fileselect").val();
//    var itemname = $("#txtItemN").val();
//    var itemprice = $("#txtItemP").val();
//    var discount = $("#txtDiscout").val();
//    var gender = $("#txtGender").val();
//    var colour = $("#txtColour").val();
//    var description = $("#txtDescription").val();
//    var date = $("#txtDate").val();
//    var model = {
//        Itemname: itemname, Itemprice: itemprice, Discount: discount, Gender: gender, Image: image, Colour: colour, Description: description, Date: date,
//    };
//    $formData.append('Image', image);
//    $formData.append('Itemname', itemname);
//    $formData.append('Itemprice', itemprice);
//    $formData.append('Discount', discount);
//    $formData.append('Gender', gender);
//    $formData.append('Colour', colour);
//    $formData.append('Description', description);
//    $formData.append('Date', date);


//    $.ajax({
//        url: "/Item/saveItem",
//        method: "Post",
//        data: $formData,
//        contentType: "application/json;charset=utf-8",
//        contentType: false,
//        processData: false,
//        success: function (response) {
//            alert("Successfull");
//            GetItemList();
          
//        }
//    })
//}