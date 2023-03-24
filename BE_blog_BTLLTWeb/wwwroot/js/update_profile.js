$(".layer-avatar").on("click", (e) => {
	$(".input-avatar").click();
});

$(".input-avatar").on("change", (e) => {
	let reader = new FileReader();
	const file = e.target.files[0];
	const image = new Image();
	reader.readAsDataURL(file);
	reader.onload = () => {
		image.src = reader.result;
		image.onload = () => {
			$(".img-avatar").attr("src", reader.result);
		};
	};
});