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
        var c = $(this).parent().find('input:eq(1)');
        var prd = $(this).parent().find('input:eq(0)').val();
        var qnt = $(this).parent().find('input:eq(1)').val();
        if (qnt > 0){
            $.ajax({
                type: "POST",
                contentType: "application/json",
                dataType: 'jSon',
                data: JSON.stringify({ 'productId': prd, 'quantity': qnt }),
                url: "http://localhost:1901/Product/AddToCart",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    BootstrapDialog.show({
                        title: 'Mensaje de confirmación',
                        message: 'Producto agregado!',
                        type: BootstrapDialog.TYPE_SUCCESS
                    });
                    c.val(0);
                    if (data.length != 0) {
                        $("#CountCart").show();
                        $("#CountCart").text(data.length);
                    } 
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }
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
                    $("#ContinueOrder").hide();
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
                if (data.UserId == 0) {
                    BootstrapDialog.confirm({
                        title: 'Advertencia',
                        message: 'Ingrese con su cuenta para confirmar el pedido',
                        type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
                        closable: true, // <-- Default value is false
                        draggable: true, // <-- Default value is false
                        btnCancelLabel: 'Aún no', // <-- Default value is 'Cancel',
                        btnOKLabel: 'Ingresar', // <-- Default value is 'OK',
                        btnOKClass: 'btn-warning', // <-- If you didn't specify it, dialog type will be used,
                        callback: function (result) {
                            // result will be true if button was click, while it will be false if users close the dialog directly.
                            if (result) {
                                window.location.href = "http://localhost:1901/Account/Login";
                            } 
                        }
                    });
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
            data: JSON.stringify({ 'address': $("#txtAddress").val(), "remark": $("#txtRemark").val(), "documentType": $("#selDocumentType").val() }),
            url: "http://localhost:1901/Order/CreateOrder",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                $('#ModalConfirm').modal('hide');
                if (data.Status == 1) {                    
                    BootstrapDialog.alert({
                        title: 'Exito al procesar',
                        message: data.Message,
                        type: BootstrapDialog.TYPE_PRIMARY
                    });

                    $("#ContinueOrder").hide();

                } else {
                    BootstrapDialog.alert({
                        title: 'Error al procesar',
                        message: data.Message,
                        type: BootstrapDialog.TYPE_DANGER
                    });
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

    $(".confirmOrder").click(function () {
        var father = $(this).parent().parent();
        var id = father.find('.id').val();
        var statusId = father.find('.statusId').val();
        $.ajax({
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ 'orderId': id, 'orderStatusId': statusId }),
            url: "http://localhost:1901/Admin/AproveOrder",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.Status == 1) {
                    $('#ModalConfirm').modal('hide');
                    BootstrapDialog.alert({
                        title: 'Exito al procesar',
                        message: data.Message,
                        type: BootstrapDialog.TYPE_PRIMARY
                    });                    
                } else {
                    BootstrapDialog.alert({
                        title: 'Advertencia',
                        message: data.Message,
                        type: BootstrapDialog.TYPE_WARNING
                    });                    
                }
                father.remove();
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    $(".cancelOrder").click(function () {
        var father = $(this).parent().parent();
        var id = father.find('.id').val();
        var statusId = 3;

        BootstrapDialog.confirm({
            title: 'Exito al procesar',
            message: 'Desea cancelar el pedido?',
            type: BootstrapDialog.TYPE_DANGER, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
            closable: true, // <-- Default value is false
            draggable: true, // <-- Default value is false
            btnCancelLabel: 'Cerrar', // <-- Default value is 'Cancel',
            btnOKLabel: 'Cancelar', // <-- Default value is 'OK',
            btnOKClass: 'btn-danger', // <-- If you didn't specify it, dialog type will be used,
            callback: function (result) {
                // result will be true if button was click, while it will be false if users close the dialog directly.
                if (result) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        dataType: "json",
                        data: JSON.stringify({ 'orderId': id, 'orderStatusId': statusId }),
                        url: "http://localhost:1901/Admin/CancelOrder",
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            if (data.Status == 1) {
                                $('#ModalConfirm').modal('hide');
                                BootstrapDialog.alert({
                                    title: 'Exito al cancelar',
                                    message: data.Message,
                                    type: BootstrapDialog.TYPE_PRIMARY
                                });
                            } else {
                                BootstrapDialog.alert({
                                    title: 'Advertencia',
                                    message: data.Message,
                                    type: BootstrapDialog.TYPE_WARNING
                                });
                            }
                            father.remove();
                        },
                        error: function (response) {
                            console.log(response);
                        }
                    });
                }
            }
        });

        
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