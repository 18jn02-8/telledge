$(function () {
	$('#raty').raty({
		target: '#review',
		starHalf: '/Assets/raty/star-half.png',
		starOff: '/Assets/raty/star-off.png',
		starOn: '/Assets/raty/star-on.png',
		hints: ['最低', '悪い', '普通', '良い', '最高']
	});
});

$(document).ready(function () {
	$("#readOnlyTags").tagit({
		readOnly: true
	}).ready(function () {
		$(this).find('.tagit-new').css('display', 'none')
	});
});

let con = new Timer(mintime, overtime);
con.setCallback(Status.Essential, function () {
	console.log("callbacked!");
});
con.setCallback(Status.Extend, () => {
	$('#timer-count').css('color', 'red');
	$('#timer-status').css('color', 'red');
	$('#timer-status').text("延長時間");
});
con.setState(Status.Essential);	//最低通話として処理
con.setTimer()


// WebSocketの処理
$(function () {
	// 1. サーバとの接続オブジェクト作成
	var connection = $.hubConnection();

	// 2. Hubのプロキシ・オブジェクトを作成
	var echo = connection.createHubProxy("Room");

	// 3. サーバから呼び出される関数を登録
	echo.on("Receive", function (text) {
		alert(text);
	});

	// RoomHubクラスのrejectRoomメソッドから呼び出す処理
	echo.on("reject", (arg) => {
		if (arg.student_id == studentId) {
			//リジェクトされたのが自分ならば

			//モーダルウィンドウの外側をクリックすることでモーダルウィンドウを閉じれないようにする
			$("#reject-modal").modal({
				backdrop: "static"
			});
			// モーダルウィンドウを開く
			$("#reject-modal").modal('show');
		}
		else {
			//リジェクトされたのが他人ならば
		}
	});

	//通話終了ボタンの入力を検知したときの処理
	$("#endCall-button").click(function () {
		echo.invoke("endCall", roomId, studentId);	//ルームの終了を知らせる信号を送信する
	});

	// 通話終了の信号を受信したときの処理
	echo.on("endCall", (room_id, student_id) => {
		if (student_id == studentId) {
			//終了対象が自分なら
			$("#review-modal").modal({
				backdrop: "static"
			});
			// モーダルウィンドウを開く
			$("#review-modal").modal('show');
			echo.invoke("LeaveStudent", roomId);	//信号の受信を終了する
		}
	});

	//通話する人を更新する処理
	// updateStudent(新たに通話する生徒番号)
	echo.on("updateStudent", (student_id) => {
		if (student_id == studentId) {
			//通話が自分の番なら　＝　自分は通話側
		}
		else {
			//通話が他人なら ＝　自分は待機側
		}
	});

	//情報を更新するメソッド
	//updateWaitInfo(更新後の予想待ち時間、更新後の待機人数)
	echo.on("updateWaitInfo", (waitTime, waitCount) => {
		$('#waitTime').text(waitTime);
		$('#waitCount').text(waitCount);
	});

	//Sectionテーブルから情報を削除する処理を実行する
	$("#leave-button").click(function () {
		echo.invoke("leaveRoom", roomId, studentId);	//RoomHubに定義されているサーバーのleaveRoomメソッドを実行する
		location.href = '/student/rooms/index';			//該当のリンクにリダイレクトする
	});

	// 4. 接続を開始
	connection.start(function () {
		// 生徒としてHubに登録する
		echo.invoke("JoinStudent", roomId);
	});
})