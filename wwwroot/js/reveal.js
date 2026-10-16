// Biyaheko scroll reveal: adds .revealed to .reveal elements as they enter view.
// Baseline-readable: if this script fails, .reveal stays visible via the
// reduced-motion/no-JS path only when animations are off; otherwise content
// below the fold reveals on scroll. Never hides content permanently.
(function () {
  if (!('IntersectionObserver' in window)) {
    document.querySelectorAll('.reveal').forEach(function (el) {
      el.classList.add('revealed');
    });
    return;
  }

  var observer = new IntersectionObserver(
    function (entries) {
      entries.forEach(function (entry) {
        if (entry.isIntersecting) {
          entry.target.classList.add('revealed');
          observer.unobserve(entry.target);
        }
      });
    },
    { threshold: 0.12 }
  );

  function watch(root) {
    root.querySelectorAll('.reveal:not(.revealed)').forEach(function (el) {
      observer.observe(el);
    });
  }

  watch(document);

  // Blazor swaps page content without reloads; watch for new nodes.
  new MutationObserver(function (mutations) {
    mutations.forEach(function (m) {
      m.addedNodes.forEach(function (node) {
        if (node.querySelectorAll) {
          watch(node.parentElement || document);
        }
      });
    });
  }).observe(document.body, { childList: true, subtree: true });
})();
