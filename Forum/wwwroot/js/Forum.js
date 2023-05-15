let discussions = [];

var getDiscussions = () => {
    fetch('/api/discussions')
        .then(response => response.json())
        .then(data => _displayDiscussions(data))
        .catch(error => console.error('Error:', error));
}

var _displayDiscussions = (data) => {
    const container = document.getElementById('discussions');

    container.innerHTML = '';
    data.forEach(discussion => {
        const discussionElem = document.createElement('div');
        discussionElem.classList.add('discussion');
        const titleElem = document.createElement('h3');
        titleElem.innerText = 'Name of discussion: ' + discussion.title;
        discussionElem.appendChild(titleElem);

        const descriptionElem = document.createElement('p');
        descriptionElem.innerText = 'Description: ' + discussion.description;
        discussionElem.appendChild(descriptionElem);

        //const editButton = document.createElement('button');
        //editButton.innerText = 'Edit';
        //editButton.setAttribute('onclick', `displayEditForm(${discussion.id})`);
        //editButton.classList.add('button-style');
        //discussionElem.appendChild(editButton);

        //const deleteButton = document.createElement('button');
        //deleteButton.innerText = 'Delete';
        //deleteButton.setAttribute('onclick', `deleteDiscussion(${discussion.id})`);
        //deleteButton.classList.add('button-style');
        //discussionElem.appendChild(deleteButton);
        const showButton = document.createElement('button');
        showButton.innerText = 'Show';
        showButton.setAttribute('onclick', `getDetailedDiscussion(${discussion.id})`);
        showButton.classList.add('button-style');
        discussionElem.appendChild(showButton);



        container.appendChild(discussionElem);
    });
    discussions = data;
}


// discussion.js

function getDiscussionById(discussionId) {
    fetch(`/api/Discussions/discussions/${discussionId}`)
        .then(response => response.json())
        .then(data => {
            document.getElementById('discussionTitle').innerText = data.title;
            document.getElementById('discussionDescription').innerText = data.description;
            document.getElementById('creationDate').innerText = data.creationDate;
        })
        .catch(error => console.log(error));
}

