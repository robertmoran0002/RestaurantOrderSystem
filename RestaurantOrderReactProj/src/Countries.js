import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './Layout';

export class Countries extends Component {
    static displayName = Countries.name;

    render() {
        return (
                <div><p>
    {/*        <a asp-action="Create">Create New</a>*/}
        </p>
    {/*    <table class="table">*/}
    {/*        <thead>*/}
    {/*            <tr>*/}
    {/*                <th>*/}
    {/*                    Country*/}
    {/*                </th>*/}
    {/*                <th>*/}
    {/*                    Region*/}
    {/*                </th>*/}
    {/*                <th></th>*/}
    {/*            </tr>*/}
    {/*        </thead>*/}
    {/*        <tbody>*/}
    {/*    @foreach (var item in Model) {*/}
    {/*            <tr>*/}
    {/*                <td>*/}
    {/*                                @Html.DisplayFor({item.CountryName})*/}
    {/*                </td>*/}
    {/*                <td>*/}
    {/*                                @Html.DisplayFor({item.Region.RegionId})*/}
    {/*                </td>*/}
    {/*                <td>*/}
    {/*                    <a asp-action="Edit" asp-route-id="@item.CountryId">Edit</a> |*/}
    {/*                    <a asp-action="Details" asp-route-id="@item.CountryId">Details</a> |*/}
    {/*                    <a asp-action="Delete" asp-route-id="@item.CountryId">Delete</a>*/}
    {/*                </td>*/}
    {/*            </tr>*/}
    {/*    }*/}
    {/*        </tbody>*/}
    {/*                </table>*/}
        </div>
           );
    }
}