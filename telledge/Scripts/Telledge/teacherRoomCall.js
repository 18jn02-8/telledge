let timer = new Timer(mintime, overtime);
timer.setCallback(Status.NotStarted, () => {
	$('#call-end').css('display', 'none');
	$('#disabled-call-end').css('display', 'none');
	$('#room-end').css('display', 'inline');

	$('#timer-title').text('通話なし');
	$('#timer-count').css('display', 'none');
	$('#timer-title').css('color', 'black');

});
timer.setCallback(Status.Essential, () => {
	$('#timer-title').text('残り時間');
	$('#timer-count').css('display', 'inline');
	$('#timer-count').css('color', 'black');
	$('#timer-title').css('color', 'black');

	$('#call-end').css('display', 'none');
	$('#disabled-call-end').css('display', 'inline');
	$('#room-end').css('display', 'none');
});
timer.setCallback(Status.Extend, () => {
	$('#timer-count').css('color', 'red');
	$('#timer-title').css('color', 'red');
	$('#timer-title').text("延長時間");
	$('#timer-count').css('display', 'inline');


	$('#call-end').css('display', 'inline');
	$('#disabled-call-end').css('display', 'none');
	$('#room-end').css('display', 'none');
});
timer.setCallback(Status.AllDone, () => {
	$('#timer-title').text("通話時間終了");
	$('#timer-title').css('color', 'red');
	$('#timer-count').css('display', 'none');

	$('#call-end').css('display', 'none');
	$('#disabled-call-end').css('display', 'none');
	$('#room-end').css('display', 'inline');

});

timer.setTimer()

// WebSocketの処理
$(function () {
	// 1. サーバとの接続オブジェクト作成
	var connection = $.hubConnection();

	// 2. Hubのプロキシ・オブジェクトを作成
	var echo = connection.createHubProxy("Room");

	// サーバから呼び出して要素を削除するメソッドを登録
	echo.on("removeStudent", function (studentId) {
		$('#student-' + studentId).remove();
	});

	// 生徒一覧への追記処理
	echo.on("append", (student_json) => {
		const id = "id=\"student-" + student_json.student_id + "\"";
		const value = "value=\"" + student_json.student_id + "\"";
		$("#student-list").append("<tr " + id + " " + value + "></tr>");
		$("#student-" + student_json.student_id)
			.append(
				"<td>" + student_json.student_name + "</td>",
				"<td>" + student_json.request + "</td>",
				"<td><button class=\"btn btn-danger\">キャンセル</button></td>"
			);
	});

	//リジェクトボタンを押したときの処理
	$(document).on("click", "#student-list button", function () {
		const $tr = $(this).closest("tr");
		const studentId = $tr.attr("value");
		echo.invoke("rejectRoom", roomId, studentId);
		$tr.remove();
	});

	// 接続を開始
	connection.start(function () {
		//サーバーのJoinTeacherメソッドを実行し、講師として登録する
		echo.invoke("JoinTeacher", roomId);
	});
});