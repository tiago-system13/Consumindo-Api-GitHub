(function ($) {
    'use strict';
    
    var cont = 0;
    var tabela = $("#datatable-repositorio").DataTable({
        destroy: true,
        processing: true,
        responsive: true,
        "paging": true,
        "deferRender": true,
        "searching": true,
        "info": true,
        serverSide: false,
        data: [],
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select><option value=""></option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
          
        },
        columnDefs: [
            {
                "defaultContent": " ",
                "targets": "_all"
            },
            {
                targets: 0,
                data: 'ID',
                render: function (data, type, full) {
                    if (full.ID != null)
                        return full.ID

                    return '';
                }
            },
            {
                targets: 1,
                data: 'Login',
                render: function (data, type, full) {
                    if (full.Login = null)
                        return full.Login;

                    return ' ';
                }
            },
            {
                targets: 2,
                data: 'Name',
                render: function (data, type, full) {
                    if (full.Name != null)
                        return full.Name;

                    return '';
                }
            },
            {
                targets: 3,
                data: 'Description',
                render: function (data, type, full) {
                    if (full.Description != null)
                        return full.Description
                    return '';
                }
            },
            {
                targets: 4,
                data: 'Language',
                render: function (data, type, full) {
                    if (full.Language != null)
                        return full.Language
                    return '';
                }
            },
            {
                targets: 5,
                data: 'Updated_at',
                render: function (data, type, full) {
                    if (full.Updated_at !== null)
                        return moment(full.Updated_at).format('DD/MM/YYYY');

                    return "";
                }
            },
            {
                targets: 6,
                data: 'Html_url',
                render: function (data, type, full) {
                    if (full.Html_url != null)

                        return full.Html_url + '<input type="text" name="contribuidores"  id="contribuidores" value="' + full.Contribuidor + '" hidden>';

                    return "";
                }
            }
        ],
        columns: [
            { data: 'ID', class: "centralizar-texto id" },
            {
                data: 'Login', class: "centralizar-texto"
            },
            {
                data: 'Name', class: "centralizar-texto"
            },
            {
                data: 'Description'
            },
            {
                data: 'Language', class: "centralizar-texto"
            },
            {
                data: 'Updated_at', class: "centralizar-texto"
            },
            {
                data: 'Html_url', class: "centralizar-texto"
            }
        ],
    });

    function carregarTable(repositorio) {
        $('#pleaseWaitDialog').modal('show');
        $.ajax({
            url: baseUrl('Repositorio/PesquisarRepositorios'),
            type: "Get",
            dataType: "json",
            data: repositorio,
            success: function (data) {                
                $('#pleaseWaitDialog').modal('hide');
                if (data.length > 0) {
                    $('#datatable-repositorio_filter').find('.input-sm:input').val('');
                    tabela.rows.add(data).draw(false);
                    
                } else {
                    $('#datatable-repositorio_filter').find('.input-sm:input').focus();
                }
            },
            error: function (response) {
                $('#datatable-repositorio_filter').find('.input-sm:input').val('');
                $('#datatable-repositorio_filter').find('.input-sm:input').focus();
                $('#pleaseWaitDialog').modal('hide');
                alert(response.responseText);
            }
        });
    }
    carregarTable({ nome: '' });

    tabela.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });

    tabela.on('search.dt', function () {
        var totalLinha = tabela.data().length;
        var linha = $('#datatable-repositorio').find('tr td').length;
        var pesquisa = $('#datatable-repositorio_filter').find('.input-sm:input').val();
        if (linha == 1 && totalLinha > 0 && pesquisa != '')
            carregarTable({ nome: pesquisa });
    });

    $('#datatable-repositorio tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $('#myModalFavorito').modal('hide');
            $(this).removeClass('selected');
        }
        else {
            tabela.$('tr.selected').removeClass('selected');
            $('#ID').val($(this).find('td:nth-child(1)').text());
            $('#lblProprietario').text($(this).find('td:nth-child(2)').text());
            $('#lblNome').text($(this).find('td:nth-child(3)').text());
            $('#lblDescricao').text($(this).find('td:nth-child(4)').text());
            $('#lblLinguagem').text($(this).find('td:nth-child(5)').text());
            $('#lblData').text($(this).find('td:nth-child(6)').text());
            $('#contribuidores').val($(this).find('td:nth-child(7)').find('#contribuidores').val());
            $('#myModalFavorito').modal('show');
            carregarTableContribuidores({ query: $(this).find('td:nth-child(7)').find('#contribuidores').val() });
            $(this).addClass('selected');
        }
    });


    var tabelaContribuintes = $("#datatable-contribuicoes").DataTable({
        destroy: true,
        processing: true,
        responsive: true,
        "paging": true,
        "deferRender": true,
        "searching": true,
        "info": true,
        serverSide: false,
        data: [],
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select><option value=""></option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        },
        columnDefs: [
            {
                "defaultContent": "",
                "targets": "_all"
            },
            {
                targets: 0,
                data: 'Name',
                render: function (data, type, full) {
                    if (full.Name != null)
                        return full.Name

                    return '';
                }
            },
            {
                targets: 1,
                data: 'Contributions',
                render: function (data, type, full) {
                    if (full.Contributions != null)
                        return full.Contributions;

                    return ' ';
                }
            },
            {
                targets: 2,
                data: 'html_url',
                render: function (data, type, full) {
                    if (full.html_url != null)
                        return full.html_url
                    return '';
                }
            }
        ],
        columns: [
            { data: 'Name', class: "centralizar-texto id" },

            {
                data: 'Contributions', class: "centralizar-texto"
            },
            {
                data: 'html_url'
            }
        ]
    });
    var contribuintes = [];
    function carregarTableContribuidores(query) {
        $.ajax({
            url: baseUrl('Repositorio/ContribuidoresDoRepositorio'),
            type: "Get",
            dataType: "json",
            data: query,
            success: function (data) {
                if (data.length > 0) {

                    tabelaContribuintes.rows.add(data).draw(false);
                    contribuintes = data;
                }
            },
            error: function (response) {
                $('#pleaseWaitDialog').modal('hide');
                alert(response.responseText);
            }
        });
    }

    $('#btnModalSalvar').click(function () {

        var formData = new FormData()
        formData.append("ID", $('#ID').val())
        formData.append("Name", $('#lblNome').text());
        formData.append("Description", $('#lblDescricao').text());
        formData.append("Updated_at", $('#lblData').text());
        formData.append("Language", $('#lblLinguagem').text());
        formData.append("Login", $('#lblProprietario').val());

        for (var j = 0; j < contribuintes.length; j++) {
            formData.append("Contribuintes[" + j + "].Name", contribuintes[j].Name);
            formData.append("Contribuintes[" + j + "].Contributions", contribuintes[j].Contributions);
            formData.append("Contribuintes[" + j + "].html_url", contribuintes[j].html_url);
        }

        $.ajax({
            url: baseUrl('Repositorio/Cadastrar'),
            type: "Post",
            dataType: "json",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {

                if (data.Sucesso) {

                    $('#msg').after('<div class="alert alert-success"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>Sucesso!</strong> ' + data.mensagem + '</div>');
                    $(".alert-success")
                        .fadeTo(2000, 500)
                        .slideUp(500, function () {
                            $(this).remove();
                            $('#myModalFavorito').modal('toggle');
                        });
                } else {
                    $('#msg').after('<div class="alert alert-danger"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>Erro!</strong> ' + data.mensagem + '</div>');
                }
            }
        });
    });

    $('#btnModalFechar').click(function () {
        $('#myModalFavorito').modal('toggle');
    });

})($ || jquery);