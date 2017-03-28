$(function () {
	
	
	$('.subnavbar').find ('li').each (function (i) {
	    debugger;
		var mod = i % 3;
		
		if (mod === 2) {
			$(this).addClass ('subnavbar-open-right');
		}
		
	});
	
	
	
});