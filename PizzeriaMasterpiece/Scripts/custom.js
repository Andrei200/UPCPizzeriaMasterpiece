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
            dataType: "json",
            data: {productId:prd,quantity:qnt},
            url: "http://localhost:1901/Product/AddToCart",
            contentType: 'application/json; charset=utf-8'
        });
        console.log('hi');
    });
});