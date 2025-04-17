import { Link } from '@tanstack/react-router';
import { Route as organizationRoute } from '../routes/organizations/$organizationId.tsx'

export default function Home() {
    return (<>
    <Link to={organizationRoute.to} params={{organizationId:'123'}}>Organizations</Link>
    </>)
}