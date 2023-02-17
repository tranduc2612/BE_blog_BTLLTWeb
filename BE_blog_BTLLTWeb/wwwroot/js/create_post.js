const inputImage = $("#image-create-post");
const imgPreview = $(".image-create-post-preview");
const regexImg = new RegExp("([a-zA-Z0-9s_\\.-:])+(.jpg|.png|.gif|.svg)$");
const errBox = $(".alert-box--error");
const messageErrBox = $(".alert-box--error p");
const susBox = $(".alert-box--success");
const messageSusBox = $(".alert-box--success p");
let idTimeOut;

$(".image-create-post-btn").on("click", (e) => {
	e.preventDefault();
	inputImage.click();
});

function showMessageAndAutoClose(openElem, closeElem, textElem, message, time) {
	openElem.fadeIn(time);
	textElem.html(message);
	closeElem.fadeOut(time);
	clearTimeout(idTimeOut);
	idTimeOut = setTimeout(() => {
		openElem.fadeOut(time);
	}, 5000);
	$(".alert-box").on("click", ".alert-box__close", function () {
		clearTimeout(idTimeOut);
		$(this).parent().fadeOut(time);
	});
}

inputImage.on("change", (e) => {
	let reader = new FileReader();
	const file = e.target.files[0];
	if (regexImg.test(inputImage.val())) {
		if (file.size > 1024 * 1024) {
			showMessageAndAutoClose(
				errBox,
				susBox,
				messageErrBox,
				"File higher than 1mb !",
				500
			);
			return;
		}
		const image = new Image();
		reader.readAsDataURL(file);
		reader.onload = () => {
			image.src = reader.result;
			image.onload = () => {
				const widthImg = image.width;
				const heightImg = image.height;
				if (widthImg >= 1000 && heightImg <= widthImg / 2 + 250) {
					imgPreview.attr("src", reader.result);
					showMessageAndAutoClose(
						susBox,
						errBox,
						messageSusBox,
						"Add image success !",
						500
					);
				} else {
					showMessageAndAutoClose(
						errBox,
						susBox,
						messageErrBox,
						"Size have to bigger than 1000x1250 !",
						500
					);
				}
			};
		};
	} else {
		showMessageAndAutoClose(
			errBox,
			susBox,
			messageErrBox,
			"The file is not correct format !",
			500
		);
	}
});

// choose topic

function toggleBtn() {}

$(".checkbox__topic").on("change", function (e) {
	if (e.target.checked == true) {
		$(`.label__topic[for=${e.target.id}]`).addClass("active");
	} else {
		$(`.label__topic[for=${e.target.id}]`).removeClass("active");
	}
});
