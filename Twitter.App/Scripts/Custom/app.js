var app = (function() {

    function showNewTweetModal() {
        $('#new-tweet-modal').modal('show');
    }

    function hideNewTweetModal() {
        $('#new-tweet-modal').modal('hide');
    }

    return {
        showNewTweetModal: showNewTweetModal,
        hideNewTweetModal: hideNewTweetModal
    }

})()