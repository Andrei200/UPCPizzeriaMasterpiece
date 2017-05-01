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
                }
            },
            error: function (response) {
                console.log(response);
            }
        });
    }
});