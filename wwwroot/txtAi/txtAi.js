document.addEventListener("keypress", async function(e){
    if(e.key === "Enter"){
        
        const input = document.getElementById('chat-input');
        const content = document.querySelector('.chat-content');

        if (input.value.trim()) {
            const message = document.createElement('p');
            message.textContent = `User Message: ${input.value}`
            message.classList.add('user-message');
            content.appendChild(message);
            try {

                /* console.log(input.value)
                console.log(JSON.stringify({
                    prompt: input.value,
                })) */

                // Requisição POST para a API
                const currentHtmlPage = window.location.href.substring(window.location.href.indexOf("/txtAi") + "/txtAi".length)
                const rootFolder = window.location.href.replace("/txtAi", "").replace(currentHtmlPage, "")
                const response = await fetch(rootFolder + '/api/UserController', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        prompt: input.value,
                    }),
                });


                /* console.log(response) */

                // Verifica se a requisição foi bem-sucedida
                if (response.ok) {
                    const responseData = await response.json();

                    // Criação e exibição da resposta da API no chat
                    const apiResponse = document.createElement('p');
                    apiResponse.textContent = `API Response: ${responseData.api_response}`;
                    apiResponse.classList.add('api-message');
                    content.appendChild(apiResponse);

                    content.scrollTop = content.scrollHeight;
                } else {
                    console.error('Erro na requisição à API:', response.statusText);
                }
            } catch (error) {
                console.error('Erro durante a requisição à API:', error.message);
            }

            input.value = '';
        }
    }
});

document.querySelector('#btn').addEventListener("click",function (e){
    const currentHtmlPage = window.location.href.substring(window.location.href.indexOf("/txtAi") + "/txtAi".length)
    const rootFolder = window.location.href.replace("/txtAi", "").replace(currentHtmlPage, "")
    window.location.href = `${rootFolder}/`
});
