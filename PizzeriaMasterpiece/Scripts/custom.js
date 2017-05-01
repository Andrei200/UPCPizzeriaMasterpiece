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
            sum += data[i].Product.Price;
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

        $('#ModalConfirm').modal('toggle');
        /*$.ajax({
            type: "POST",
            contentType: "application/json",            
            url: "http://localhost:1901/Account/CallUser",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data == null) {
                    console.log('lol');
                } else {
                    BootstrapDialog.alert('I want banana!');

                }                
            },
            error: function (response) {
                console.log(response);
            }
        });*/
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