import {Route} from '../../routes/organizations/$organizationId';

export default function OrganizationPage()
{
    const model = Route.useLoaderData();

    return (<h1>Organization {model.organizationId}</h1>)
}