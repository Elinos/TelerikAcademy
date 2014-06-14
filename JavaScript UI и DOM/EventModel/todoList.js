var input = document.getElementById('task-input'),
  addBtn = document.getElementById('addBtn'),
  taskLi = document.createElement('li'),
  taskText = document.createElement('span'),
  taskCloseBtn = document.createElement('a'),
  taskList = document.getElementById('task-list');

taskList.style.listStyle = 'none';
taskList.style.padding = '5px';

taskCloseBtn.className = 'close';
taskCloseBtn.innerHTML = '&times;';
taskCloseBtn.style.paddingLeft = '10px';

addBtn.addEventListener('click', function() {
  if (input.value.length > 0) {
    var task = taskLi.cloneNode(true),
      closeBtn = taskCloseBtn.cloneNode(true),
      text = taskText.cloneNode(true);

    text.innerHTML = input.value;

    closeBtn.addEventListener('click', function() {
      taskList.removeChild(this.parentNode);
    });

    text.addEventListener('click', function() {
      text.style.textDecoration = text.style.textDecoration === 'line-through' ? '' : 'line-through';
    });

    task.appendChild(text);
    task.appendChild(closeBtn);

    taskList.appendChild(task);
  }
});
