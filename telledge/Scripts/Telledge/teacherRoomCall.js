let timer = new Timer(mintime, overtime);
timer.setCallback(Status.Essential, () => {
	$('#timer-title').text('残り時間');
	$('#timer-count').css('color', 'black');
	$('#timer-title').css('color', 'black');
});
timer.setCallback(Status.Extend, () => {
	$('#timer-count').css('color', 'red');
	$('#timer-title').css('color', 'red');
	$('#timer-title').text("延長時間");
});
timer.setState(Status.Essential);	//最低通話として処理
timer.setTimer()