if (document.getElementById('home-fixture')) {
  // Fixture selector
  $('.fixture-selector').on('click', 'div', function() {
    var $div = $(this);
    var fixtureType = $div.data('fixture-type');

    $.get(window.location.pathname + 'fixture/' + fixtureType + '/summary', function(partial) {
      $('#fixture-summary-container').html(partial);

      $div.siblings().removeClass('selected-fixture');

      $div.addClass('selected-fixture');
    });
  });
}