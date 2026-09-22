document.addEventListener("DOMContentLoaded", () => {
	profileBannerTextWiggleAnimation();
	indexNavigationScrollSpy();
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

function indexNavigationScrollSpy() {
	const navigationItems = [...document.querySelectorAll(".index-navigation-item")];

	const sections = navigationItems.map(navigationItem => document.querySelector(navigationItem.getAttribute("href"))).filter(Boolean);

	const visibleSections = new Set();

	const toggleActive = (section) => {
		const activeNavigationItem = navigationItems.find(navigationItem => navigationItem.getAttribute("href") === `#${section.id}`);

		if (!activeNavigationItem) return;

		navigationItems.forEach(navigationItem => navigationItem.classList.toggle("active-section", navigationItem === activeNavigationItem));
	};

	// Use IntersectionObserver to detect which sections are currently visible in the viewport.
	const observer = new IntersectionObserver(
		entries => {
			entries.forEach(entry => entry.isIntersecting ? visibleSections.add(entry.target) : visibleSections.delete(entry.target));

			const currentSection = [...visibleSections].sort((a, b) => a.getBoundingClientRect().top - b.getBoundingClientRect().top)[0];

			// If no sections are within the viewport, default to the first section.
			currentSection ? toggleActive(currentSection) : toggleActive(sections[0]);
		},
		{
			rootMargin: "-12.5% 0px -70% 0px"
		}
	);

	sections.forEach(section => observer.observe(section));
}

