# MultiSelectQueryParams
Passar parâmetros MultiSelect via QueryParams

### Bootstrap Multiselect
Foi utilizado a implementação [David Stutz](http://davidstutz.de/bootstrap-multiselect/#getting-started)

### Motivação
Após realizar algumas pesquisas encontrei um post onde apresentava o mesmo problema [stack**overflow**](https://stackoverflow.com/questions/1763508/passing-arrays-as-url-parameter)
com a necessidade de passar os valores selecionados de um DropDown do tipo MultiSelect para o método via QueryParams identifiquei que os valores são passados via url. 
>example.com?aParam[]=value1&aParam[]=value2&aParam[]=value3

Quando passamos o array somente o primeiro valor do array é passado, para conter esse problema é necessário passar o array com a posição e valor.
>example.com?aParam[0]=value1&aParam[1]=value2&aParam[2]=value3



**Obs:** _Na documentação não encontrei nada que informe a maneira correta de passar os parâmetros_.

### Contribuição
[Juliano Duarte](https://github.com/jduartee) utiliza o trecho de código a baixo, para enviar os parametros.
```
function getFormData($form) {
    let unindexed_array = $form.serializeArray();
    let indexed_array = {};
    let x = 0;
    let item;
    let newItem;
    $.map(unindexed_array, function (n, i) {
       indexed_array[n['name']] = n['value'];
    });
    return indexed_array;
}
```
Onde serializa os campos e retorna um objeto.

### Exemplo
A versão orignal da function monta o parâmetro do seguinte formato:

>![parte_0](https://user-images.githubusercontent.com/30089341/51806630-d8ba4d80-225a-11e9-8030-22087dc3aadb.PNG)

Realizamos a implementação, quando encontrar um elemento do tipo **_object_** ele monta o elemento inserindo a posição e valor.
```
if (typeof $(`#${n['name']}`).val() == 'object') {
    if ((indexed_array[n['name']] == undefined)) {
        newItem = n['name']
        if (newItem != item)
            x = 0
        indexed_array[`${n['name']}[${[x++]}]`] = n['value'];
    }
}
else {
    indexed_array[n['name']] = n['value'];
}
item = n['name'];
```

A function ficou assim:

```
function getFormData($form) {
    let unindexed_array = $form.serializeArray();
    let indexed_array = {};
    let x = 0;
    let item;
    let newItem;
    $.map(unindexed_array, function (n, i) {
        if (typeof $(`#${n['name']}`).val() == 'object') {
            if ((indexed_array[n['name']] == undefined)) {
                newItem = n['name']
                if (newItem != item)
                    x = 0
                indexed_array[`${n['name']}[${[x++]}]`] = n['value'];
            }
        }
        else {
            indexed_array[n['name']] = n['value'];
        }
        item = n['name'];
    });
    return indexed_array;
}
```

Agora temos os parâmetros da maneira correta:

>![parte_2](https://user-images.githubusercontent.com/30089341/51806664-5a11e000-225b-11e9-9b1f-522c88f95732.PNG)

O método esta esperando no seguinte formato:

>![parte_4](https://user-images.githubusercontent.com/30089341/51806702-e3291700-225b-11e9-82a1-50b0bb0c3232.PNG)

Passando os valores da maneira correta, então preenchemos nossa classe:

>![parte_3](https://user-images.githubusercontent.com/30089341/51806720-14a1e280-225c-11e9-83bc-3aa746ee9c16.PNG)

### Autor
* Fábio Trindade
