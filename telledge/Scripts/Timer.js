/*
 * 構造例
 * <タグ id="parent_selector引数">
 *	<タグ id="timer-status"></タグ>
 *	<タグ id="timer-count"></タグ>
 * </タグ>
 */

const Status = {
	Undefined: 0,
	NotStarted: 1,
	Essential: 2,
	Extend: 3,
	AllDone: 4
};

class Timer{
	constructor(parent_selector, mintime, overtime) {
		this.selector = parent_selector;
		this.mintime = mintime;
		this.overtime = overtime;
		this.status = Status.NotStarted;
	}

	setState(statusCode) {
		this.status = statusCode;
		if (this.status == Status.NotStarted) {
			//開始前の処理
		}
		if (this.status == Status.Essential) {
			this.sec = this.mintime * 60;
		}
		else if (this.status == Status.Extend) {
			this.sec = this.overtime * 60;
			$(this.selector).children('#timer-count').css('color', 'red');
			$(this.selector).children('#timer-status').css('color', 'red');
			$(this.selector).children('#timer-status').text("延長時間");
		}
		else if (this.status == Status.AllDone) {
			//すべての処理が完了したときの処理
		}
		else {
			this.status = Status.Undefined;
		}
	}
	getState() {
		return this.status;
	}
	showTime() {
		//secを適切な形に変換して表示する
		const min = this.sec / 60;
		const sec = this.sec % 60;
		$(this.selector).children('#timer-count').text(parseInt(min) + ":" + parseInt(sec));
	}

	setTimer() {
		//secを減らす
		let sec = this.sec;
		const interval = setInterval(() => {
			this.showTime();
			this.sec--;
			if (this.sec < 0) {
				this.status++;
				this.setState(this.status);
			}
		}, 1000);
	}
}