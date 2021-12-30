if (document.getElementById('home-index')) {
  // Animate the SVG paths in the light at the top of the page.
  $('header path').each(function(i, path) {
    var length = path.getTotalLength();

    path.style.transition = path.style.WebkitTransition = 'none';

    path.style.strokeDasharray = length + ' ' + length;
    path.style.strokeDashoffset = length;

    // Force a paint/layout.
    path.getBoundingClientRect();

    // Animate the dash offset back to 0 to 'draw' the paths over three seconds.
    path.style.transition = path.style.WebkitTransition = 'stroke-dashoffset 3s ease-in-out';
    path.style.strokeDashoffset = '0';

    setTimeout(function() {
      $('header').addClass('animation-complete');
    }, 2500);
  });

  $('.show-more.toggle-benefits').on('click', function(evt) {
    $('section.benefits-of-leasing').slideDown(1000, 'easeInOutExpo', function() {

      $('.benefits-toggle-container .show-more').fadeOut(100, function() {
        $('.benefits-toggle-container .show-less').fadeIn(100);
      });
    });
                                     
    evt.preventDefault();
  });

  $('.show-less.toggle-benefits').on('click', function(evt) {
    $('section.benefits-of-leasing').slideUp(1000, 'easeInOutExpo', function() {

      $('.benefits-toggle-container .show-less').fadeOut(100, function() {
        $('.benefits-toggle-container .show-more').fadeIn(100);
      });
    });

    evt.preventDefault();
  });

  $('#region-selection .dropdown a').on('click', function(evt) {
    // If we have HTML5 history support, change the URL to include an OpCo and then
    //  make the necessary client-side changes to avoid needing a full page load.
    if (Modernizr.history) {
      evt.preventDefault();

      $('.dropdown button .dropdown-text').text($(this).text());

      var href = this.href;
      var opco = $(this).text().toLowerCase().replace(/\s/g, '-');

      // Shoebox is the first/default fixture so show it first to get things started.
      $.get(href + 'fixture/shoebox/summary', function(partial) {
        $('#fixture-summary-container').html(partial);

        window.history.replaceState(href.replace('/', ''), 'Entergy Security Lighting', href);

        $('body').removeClass(regions.join(' '))
                 .addClass(opco);
      });

      // Fix the links in the fixture selector by replacing the dummy no-region OpCo token
      //  with the actual OpCo, otherwise the URLs will be invalid.
      $('.fixture-selector a').each(function() {
        this.href = this.href.replace('no-region', opco);
      });
    }
  });

  // Fixture selector
  $('.fixture-selector').on('click', 'a', function(evt) {
    evt.preventDefault();

    var $div = $(this).parent();

    $.get(this.href + '/summary', function(partial) {
      $('#fixture-summary-container').html(partial);

      $div.siblings().removeClass('selected-fixture');

      $div.addClass('selected-fixture');
    });
  });


  // FAQ expand/collapse feature
  $('dt').on('click', function(evt) {
    $(this).toggleClass('collapsed');
  });

  // FAQs show more/less buttons
  $('#faqs .show-more').on('click', function(evt) {
    $(this).parent().hide();

    $('#faqs .more-faqs').slideDown();

    evt.preventDefault();
  });

  $('#faqs .show-less').on('click', function(evt) {
    evt.preventDefault();

    $('#faqs .more-faqs').slideUp(500, function() {
      $('#faqs .show-more-container').fadeIn(250);
    });
  });
}