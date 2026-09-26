document.addEventListener("DOMContentLoaded", () => {
	profileBannerTextWiggleAnimation();
	indexNavigationScrollSpy();
	countCommentFormMessageCharacters();
	commentForm();
});

function profileBannerTextWiggleAnimation() {
	const paragraph = document.querySelector(".profile-banner-text") ?? null;

	if (!paragraph) return;
	
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
	const navigationItems = [...document.querySelectorAll(".index-navigation-item")] ?? null;

	if (!navigationItems) return;

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

function countCommentFormMessageCharacters() {
	const commentMessage = document.querySelector("#comment-form-message") ?? null;
	const commentMessageMax = document.querySelector(".comment-form-message-max") ?? null;

	if (!commentMessage || !commentMessageMax) return;

	commentMessage.addEventListener("input", () => {
		commentMessageMax.textContent = commentMessage.value.length;
	});
}

function commentForm() {
	const commentForm = document.querySelector(".comment-form") ?? null;

	if (!commentForm) return;

	const submitButton = commentForm.querySelector("button[type=\"submit\"]");

	// Enable or disable the submit button based on the form's validity.
	commentForm.querySelectorAll(".comment-form input, .comment-form textarea").forEach(input => {
		input.addEventListener("input", () => {
			const isValid = commentForm.checkValidity();
			submitButton.disabled = !isValid;
		});
	});

	// Handle form submission with AJAX to prevent page reload and allow for server-side validation.
	commentForm.addEventListener("submit", async (event) => {
		event.preventDefault();

		const form = event.target;
		const formData = new FormData(form);

		const response = await fetch(form.action, {
			method: "POST",
			body: formData,
			headers: {
				"RequestVerificationToken": form.querySelector('input[name="__RequestVerificationToken"]').value
			}
    });

		if (response.ok) {
			document.querySelector("#comment-popup").close();
			form.querySelector(".comment-form-message-max").textContent = "0";
			form.reset();

			insertCommentIntoGuestbook(formData);
			displaySuccessToast();
		}
	});

	// Insert the new comment into the guestbook without reloading the page.
	const insertCommentIntoGuestbook = (formData) => {
		const commentTemplateClone = document.querySelector("#comment-card-template").content.cloneNode(true);

		const commentList = document.querySelector(".comment-list");

		commentTemplateClone.querySelector(".comment-card-initial").textContent = formData.get("UserComment.Author").charAt(0);
		commentTemplateClone.querySelector(".comment-card-author").textContent = formData.get("UserComment.Author");
		commentTemplateClone.querySelector(".comment-card-datetime").textContent = "Nu";
		commentTemplateClone.querySelector(".comment-card-message").textContent = formData.get("UserComment.Message");

		// Limit the number of comments displayed to 10 by removing the last comment if necessary.
		if (commentList.childElementCount >= 10) {
			commentList.lastElementChild.remove();
		}

		commentList.prepend(commentTemplateClone);
	}

	// Display a success toast message to the user after successfully submitting a comment.
	const displaySuccessToast = () => {
		const toast = document.createElement("div");
		toast.className = "comment-success-toast";
		toast.textContent = "Tak for din besked, den er nu tilføjet til gæstebogen!";
		document.body.appendChild(toast);

		setTimeout(() => document.body.removeChild(toast), 5000);
	}
}
