export class RoleMapper {
    static RoleMapping(roleName: string): number {
        switch (roleName) {
            case 'Admin': return 2;
            case 'Tutor': return 1;
            case 'User': return 0;
            default: return -1;
        }
    }
}