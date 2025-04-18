import { Link } from '@tanstack/react-router';
import { Route as organizationRoute } from '../routes/organizations/$organizationId.tsx'

export default function Home() {
    return (<>
    <Link to={organizationRoute.to} params={{organizationId:'21d13860-d232-4de5-b07c-4f04ff6cd864'}}>Organizations</Link>
    </>)
}