document.addEventListener("DOMContentLoaded", () => {
	profileBannerTextWiggleAnimation();
});

function profileBannerTextWiggleAnimation() {
	const paragraph = document.querySelector(".profile-banner-text");
	
	const random = (min, max) => Math.random() * (max - min) + min;
	
	const text = paragraph.textContent;

	paragraph.textContent = "";

	[...text].forEach(char => {

		// Preserve spaces without wrapping them
		if (char === " ") {
			paragraph.appendChild(document.createTextNode(" "));
			return;
		}

		const span = document.createElement("span");
		span.textContent = char;

		// Give each character 3 random positions within ±5% and rotations within ±5deg.
		for (let i = 1; i <= 3; i++) {
			span.style.setProperty(
				`--x${i}`,
				`${random(-5, 5)}%`
			);

			span.style.setProperty(
				`--y${i}`,
				`${random(-5, 5)}%`
			);

			span.style.setProperty(
				`--r${i}`,
				`${random(-5, 5)}deg`
			);
		}

		// Make every character move at a slightly different speed and start at a different point.
		span.style.animationDuration =
			`${random(2.5, 4.5)}s`;

		span.style.animationDelay =
			`${random(-4.5, 0)}s`;

		paragraph.appendChild(span);
	});
}
