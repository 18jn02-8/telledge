class Timer{
	constructor(mintime, overtime) {
		this.mintime = mintime;
		this.overtime = overtime;
	}
	minTime() {
		var flag = 0;
		var count = 0;
		var id = setInterval(function () {
			var mintimer = (parseInt(mintime) * 60) - count;
			var min = mintimer / 60;
			var sec = mintimer % 60;
			$('te').text(parseInt(min) + ":" + parseInt(sec));
			count++;
			if (mintimer <= 0) {
				flag = 1;
				clearInterval(id); //idをclearIntervalで指定している
			}
		}, 1000);
		return flag;
	}
	overTime() {
		var count = 0;
		var id = setInterval(function () {
			var overtimer = (parseInt(overtime) * 60);
			var min = count / 60;
			var sec = count % 60;
			$('te').text(parseInt(min) + ":" + parseInt(sec));
			count++;
			if (overtimer < count) {
				clearInterval(id);　//idをclearIntervalで指定している
			}
		}, 1000);
	}

	typeSection(mintime,overtime) {
	}
}

/*$.ajax({
	url: './request.php',
	type: 'POST',
	data: {
		'userid': $('#userid').val(),
		'passward': $('#passward').val()
	}
})
	// Ajaxリクエストが成功した時発動
	.done((data) => {
		$('.result').html(data);
		console.log(data);
	})
	// Ajaxリクエストが失敗した時発動
	.fail((data) => {
		$('.result').html(data);
		console.log(data);
	})
	// Ajaxリクエストが成功・失敗どちらでも発動
	.always((data) => {

	});
	*/
var flag = 0;
if(con.minTime());
var con = new Timer(mintime, overtime);
if (flag != 1) con.overTime();