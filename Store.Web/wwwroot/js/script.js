$(document).ready(function() {
// Сортировка данных в таблице
$('#myTable').tablesorter(); 
// Подсветка строки в таблице
$('#myTable tbody tr').hover(function() {
$(this).addClass('backlight');
}, function() {
$(this).removeClass('backlight');
});
// Выделение строк в таблице
$('#myTable tbody tr').click(function() {
$(this).toggleClass('selectlines');
});
});