$(document).ready(function () {
    $(".filter-button").click(function () {
        $(".filter-button").removeClass('active');
        $(this).addClass('active');
        var value = $(this).attr('data-filter');
        if (value == "all") {
            //$('.filter').removeClass('hidden');
            $('.filter').show('1000');
        }
        else {
            $(".filter").not('.' + value).hide('3000');
            $('.filter').filter('.' + value).show('3000');
        }
    });

    $(".btn-order-pizza").click(function () {
        var prd = $(this).parent().find('input:eq(0)').val();
        var qnt = $(this).parent().find('input:eq(1)').val();
        $.ajax({
            type: "POST",
            contentType: "application/json",
            dataType: 'jSon',
            data: JSON.stringify({ 'productId': prd, 'quantity': qnt }),
            url: "http://localhost:1901/Product/AddToCart",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                BootstrapDialog.show({
                    message: 'Producto agregado!',
                    type: BootstrapDialog.TYPE_SUCCESS
                });
                if (data.length != 0) {
                    $("#CountCart").show();
                    $("#CountCart").text(data.length);
                } 
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    function sum(data) {
        var sum = 0;
        for (var i = 0; i < data.length; i++) {
            sum += (data[i].Product.Price * data[i].Quantity);
        }
        return sum.toFixed(2);
    }

    $(".btn-delete-order-item").click(function () {
        var register = $(this).parent().parent();
        var row = register.find('.rowID').val();
        
        $.ajax({
            type: "POST",
            contentType: "application/json",
            dataType: 'jSon',
            data: JSON.stringify({ 'rowID': row }),
            url: "http://localhost:1901/Cart/DeleteItem",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.length != 0) {
                    $("#CountCart").show();
                    $("#CountCart").text(data.length);
                } else {
                    $("#CountCart").hide();
                }               
                $("#CartTotal").text(sum(data));
                register.remove();
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    $("#ContinueOrder").click(function () {       
        $.ajax({
            type: "POST",
            contentType: "application/json",
            dataType: "json",            
            url: "http://localhost:1901/Account/CallUser",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data == null) {
                    BootstrapDialog.alert('Ingrese su sessión!');
                } else {
                    $("#txtAddress").val(data.Address);
                    $('#ModalConfirm').modal('toggle');
                }                
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    $("#ConfirmOrder").click(function () {        
        $.ajax({
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ 'address': $("#txtAddress").val(), "remark": $("#txtRemark").val(), "documentType": 1 }),
            url: "http://localhost:1901/Order/CreateOrder",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.Status == 1) {
                    $('#ModalConfirm').modal('hide');
                    BootstrapDialog.alert(data.Message);//cambiar color del modal
                } else {
                    BootstrapDialog.alert(data.Message);
                }
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    $(".viewDetail").click(function () {
        var id = $(this).parent().parent().find('.id').val();
        var order = $(Orders).filter(function (index, item) { return item.OrderId == id })[0];
        $('#ModalDetail').modal('toggle');
        $("#ModalDetailOrderNo").text(order.OrderNo);
        $("#ModalDetailTableDetail").empty();
        for (var oo = 0; oo < order.OrderDetails.length; oo++) {
            $("#ModalDetailTableDetail").append("<tr><td>" + order.OrderDetails[oo].Quantity + "</td>" + "<td>" + order.OrderDetails[oo].ProductName + "</td>" + "<td class='text-right'>S/. " + order.OrderDetails[oo].Price.toFixed(2) + "</td>" + "<td class='text-right'>S/. " + order.OrderDetails[oo].TotalPrice.toFixed(2) + "</td></tr>");
        }
    });

    callSession();
    function callSession() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            dataType: 'jSon',            
            url: "http://localhost:1901/Product/CheckCart",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.length != 0) {
                    $("#CountCart").show();
                    $("#CountCart").text(data.length);
                } else {
                    $("#CountCart").hide();
                }
                $("#CartTotal").text(sum(data));
            },
            error: function (response) {
                console.log(response);
            }
        });
    }
});