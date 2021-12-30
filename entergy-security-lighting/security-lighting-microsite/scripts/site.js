var regions = [
  'no-region',
  'mississippi',
  'gulf-states-louisiana',
  'louisiana',
  'texas',
  'arkansas',
  'new-orleans'
];

var animateScrollTo = function($element) {
  var scrollTarget = $element.offset().top;

  var duration = (Math.abs($(window).scrollTop() - scrollTarget)) / $('body').height() * 3000;

  $('html, body').animate({
    scrollTop: scrollTarget - $('.navbar').height()
  }, duration, 'easeInOutExpo');
};

$('#nav-menu a').on('click', function(evt) {
  evt.preventDefault();

  var $target = $(this.href.match(/#.*/)[0]);

  animateScrollTo($target);
});

$('#available-fixtures .fixture-filter a').on('click', function(evt) {
  evt.preventDefault();

  $('#available-fixtures').removeClass('commercial-fixtures residential-fixtures')
                          .addClass($(this).data('filter'));

  $('#application-type span:first').text($(this).text());
});

// Temporary handler to simulate eventual functionality.
$('.thumbnails img').on('click', function() {
  $('.installation-viewer img:first').attr('src', $(this).attr('src'));
});

var monitor_scroll = function(evt) {
  var firstVisibleSection = $('header, section:visible').filter(':in-viewport(78)').first();

  $('#current-section-name').text(firstVisibleSection.data('nav-text'));
}

monitor_scroll();

$(window).on('scroll', $.throttle(250, monitor_scroll));

// Contact form collapse/expand
$('#contact-show').on('click', function() {
  $(this).hide();

  $('.contact-form').slideDown(500, 'easeInOutSine');
});

$('#nav-contact-us, #faq-contact-us').on('click', function() {
  $('#contact-show').click();

  animateScrollTo($('section.contact'));
});

$('#contact-send').on('click', function(evt) {
  evt.preventDefault();

  var model = {};

  $('.contact-form input, .contact-form select').map(function() {
    model[this.id] = $(this).val();
  });

  $.ajax($('.contact-form').attr('action'), {
    data: model,
    type: 'post',
    success: function(response) {
      console.log(response);
    }
  })
});